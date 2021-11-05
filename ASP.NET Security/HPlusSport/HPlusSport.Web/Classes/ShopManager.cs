using HPlusSport.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace HPlusSport.Web.Classes
{
    public static class ShopManager
    {
        private const string sessionName = "cart";

        public static List<Article> GetCart()
        {
            var articles = HttpContext.Current.Session[sessionName] as List<Article>;
            if (articles == null)
            {
                articles = new List<Article>();
            }
            return articles;
        }

        public static bool AddToCart(Article article)
        {
            var articles = GetCart();
            if (articles.Contains(article))
            {
                return false;
            }
            else
            {
                articles.Add(article);
                HttpContext.Current.Session[sessionName] = articles;
                return true;
            }
        }

        public static bool RemoveFromCart(Article article)
        {
            var articles = GetCart();
            if (!articles.Contains(article))
            {
                return false;
            }
            else
            {
                articles.Remove(article);
                HttpContext.Current.Session[sessionName] = articles;
                return true;
            }
        }

        public static Order CreateOrder()
        {
            var articles = GetCart();
            if (articles.Count() == 0)
            {
                throw new InvalidOperationException("Shopping cart is empty");
            }
            using (var db = new ShopContext())
            {
                var userId = -1;
                var userIdFromClaim =
                    (HttpContext.Current.User.Identity as ClaimsIdentity).Claims
                    .Single(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (!string.IsNullOrEmpty(userIdFromClaim) &&
                    int.TryParse(userIdFromClaim, out userId))
                {
                    var order = new Order()
                    {
                        Articles = articles,
                        OrderDate = DateTime.Now,
                        User = db.Users.Single(u => u.Id == userId)
                    };
                    db.Orders.Add(order);
                    db.SaveChanges();
                    EmptyCart();
                    return order;
                } else
                {
                    throw new InvalidOperationException("User unknown");
                }
            }
        }

        private static bool EmptyCart()
        {
            HttpContext.Current.Session.Remove(sessionName);
            return true;
        }
    }
}