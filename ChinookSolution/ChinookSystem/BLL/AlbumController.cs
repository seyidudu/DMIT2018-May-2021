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
    public class AlbumController
    {
        #region Queries
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<AlbumItem> Albums_GetByArtist(int artistid)
        {
            using (var context = new ChinookSystemContext())
            {
                //this code uses a Linq query
                //this example uses "query" syntax
                IEnumerable<AlbumItem> results = from x in context.Albums
                                                 where x.ArtistId == artistid
                                                 select new AlbumItem
                                                 {
                                                     AlbumId = x.AlbumId,
                                                     Title = x.Title,
                                                     ArtistId = x.ArtistId,
                                                     ReleaseYear = x.ReleaseYear,
                                                     ReleaseLabel = x.ReleaseLabel
                                                 };
                return results.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<AlbumItem> Albums_List()
        {
            using (var context = new ChinookSystemContext())
            {
                //this code uses a Linq query
                //this example uses "query" syntax
                IEnumerable<AlbumItem> results = from x in context.Albums
                                                 select new AlbumItem
                                                 {
                                                     AlbumId = x.AlbumId,
                                                     Title = x.Title,
                                                     ArtistId = x.ArtistId,
                                                     ReleaseYear = x.ReleaseYear,
                                                     ReleaseLabel = x.ReleaseLabel
                                                 };
                return results.ToList();
            }
        }
        #endregion
        public List<ArtistAlbumsByTitleandYear> Album_ListArtistAlbumsByTitleandYear()
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<ArtistAlbumsByTitleandYear> results = context.Albums
                            .OrderBy(x => x.Artist.Name)
                            .ThenBy(x => x.Title)
                            .ThenByDescending(x => x.ReleaseLabel)
                            .Where(x => x.ReleaseYear >= 1980 && x.ReleaseYear < 1990)
                            .Select(x => new ArtistAlbumsByTitleandYear
                            {
                                Artist = x.Artist.Name,
                                Title = x.Title,
                                Year = x.ReleaseYear,
                                Label = x.ReleaseLabel == null ? "Unknown" : x.ReleaseLabel
                            });
                return results.ToList();
            }
        }
        #region Add, Update and Delete CRUD
        //Add
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public int Albums_Add(AlbumItem album)
        {
            using (var context = new ChinookSystemContext())
            {
                //due to the fact that we have separated the handling of our entities
                //      from the data transfer between web app and class library
                //      using thr ViewModel classes, we MUST create and instance
                //      of the entity and move trhe data from the ViewModel class
                //      to the entity instance
                Album addAlbum = new Album()
                {
                    //why no pkey set?
                    //pkey is an identity pkey, no value is needed
                    Title = album.Title,
                    ArtistId = album.ArtistId,
                    ReleaseYear = album.ReleaseYear,
                    ReleaseLabel = album.ReleaseLabel
                };
                // staging
                //setup in local memory
                //at this point you will NOT have sent anything to the database
                //      therefore, you will not have you new pkey as yet
                context.Albums.Add(addAlbum);

                //commit to database
                //on this command you
                //  a) execute entity validation annotation
                //  b) send your local memory staging  to the database for execution
                //after a sucessful execution your entity instance will have the 
                //      new pkey (identity) value
                context.SaveChanges();

                //at this point, your identtity instance has the new pkey value
                return addAlbum.AlbumId;
            }

           

        }
        //Update
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Album_Update(AlbumItem item)
        {
            using (var context = new ChinookSystemContext())
            {
                Album updateItem = new Album
                {
                    //for an update, you need to supply your pkey value ... this is to identify the record that is to be updated
                    AlbumId = item.AlbumId,
                    Title = item.Title,
                    ArtistId = item.ArtistId,
                    ReleaseYear = item.ReleaseYear,
                    ReleaseLabel = item.ReleaseLabel
                };

                // staging
                //setup in local memory

                context.Entry(updateItem).State = System.Data.Entity.EntityState.Modified;

                //commit to database
                //on this command you
                //  a) execute entity validation annotation
                //  b) send your local memory staging  to the database for execution

                context.SaveChanges();
            }
        }

        //Delete

        //when we do an ODS CRUD on the delete, the ODS send in the entire
        //  instance record, not just the key value

        //overload the Album_Delete method so it recive a whole instance
        //      then call the actual delete method passing just the 
        //      pkey value to the actual delete method
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Album_Delete(AlbumItem item)
        {
            Album_Delete(item.AlbumId);
        }
        public void Album_Delete(int albumid)
        {
            using (var context = new ChinookSystemContext())
            {
                //example of a physical delete
                //this is where the record is physically removed from the databasr
                //thus, you will do a >removr(0
                //retrieve the current entity instance based in the incoming parameter
                var exist = context.Albums.Find(albumid);
                // the results is either the record or a null
                if(exist == null)
                {
                    throw new Exception($"No album with the id of ({albumid}) exists on file ");
                }
                //staged the remove
                context.Albums.Remove(exist);
                //commit the remove
                context.SaveChanges();

                //example of a logical delete
                //this is where you will set an attribute on the database record
                //  which logical indicates not to use the record
                //a logical delete is actually an update if the instance
            }
        }
        #endregion
    }
}

