using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clashCenter.Models.ResponseObjects
{
    public class UserDetailsResponseViewModel
    {
        public UserDetailsResponseViewModel()
        {
            Favorites = new List<FavoriteViewModel>();
        }
        public string UserID { get; set; }
        public string Username { get; set; }
        public List<FavoriteViewModel> Favorites { get; set; }
    }
}