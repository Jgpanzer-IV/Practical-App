using Suntrack.Shared;
using System.Collections.Generic;


namespace NorthwindMVC.Models{

    public class HomeIndexViewModel{

        public uint VisitorCount {get; private set;}
        public IList<Category> Categories {get; private set;} 
        public IEnumerable<Product> TopMostProducts{get;private set;}

        public HomeIndexViewModel(uint visitorCount,IList<Category> categories, IEnumerable<Product> topPosition){
            VisitorCount = visitorCount;
            Categories = categories;
            TopMostProducts = topPosition;
           
        }
    }




}