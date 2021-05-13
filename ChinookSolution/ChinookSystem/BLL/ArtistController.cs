using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional namespaces
using ChinookSystem.DAL;
using ChinookSystem.Entities;
using ChinookSystem.ViewModels;
#endregion
namespace ChinookSystem.BLL
{
    [DataObject]
    public class ArtistController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SelectionList> Artists_List()
        {
            using (var context = new ChinookSystemContext())
            {
                //this code uses a Linq query
                //this example uses "method" syntax
                IEnumerable<SelectionList> results = context.Artists
                                                     .Select(row => new SelectionList
                                                     {
                                                         ValueField = row.ArtistId,
                                                         DisplayField = row.Name
                                                     });

                                                    //from x in context.Artists
                                                     //select new SelectionList
                                                     //{
                                                     //    ValueField = x.ArtistId,
                                                     //    DisplayField = x.Name
                                                     //};
                return results.OrderBy(x =>x.DisplayField).ToList();
            }
        }
    }
}
