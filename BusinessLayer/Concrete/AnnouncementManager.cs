using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDal announcementDal;
        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            this.announcementDal = announcementDal;
        }
        public void TAdd(Announcement entity)
        {
            announcementDal.Insert(entity);
        }

        public void TDelete(Announcement entity)
        {
            announcementDal.Delete(entity);
        }

        public Announcement TGetById(int id)
        {
            return announcementDal.GetById(id);
        }

        public List<Announcement> TGetList()
        {
            return announcementDal.GetList();
        }

        public void TUpdate(Announcement entity)
        {
            announcementDal.Update(entity);
        }
    }
}
