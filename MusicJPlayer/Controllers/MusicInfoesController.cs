using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicJPlayer.Models;
using System.IO;
using System.Data.Entity.Infrastructure;

namespace MusicJPlayer.Controllers
{
    public class MusicInfoesController : Controller
    {
        private MusicJPlayerContext db = new MusicJPlayerContext();

        // GET: MusicInfoes
        public ActionResult Index()
        {
            return View(db.MusicInfos.ToList());
        }

        // GET: MusicInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicInfo musicInfo = db.MusicInfos.Find(id);
            if (musicInfo == null)
            {
                return HttpNotFound();
            }
            return View(musicInfo);
        }

        // GET: MusicInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusicInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MusicInfoId,Title,Artist,CoverArt,Description")] MusicInfo musicInfo, HttpPostedFileBase upload, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //List<FileDetail> fileDetails = new List<FileDetail>();
                    //for (int i = 0; i < Request.Files.Count; i++)
                    //{

                    //    var file = Request.Files[i];


                    //}
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var uploadFile = Path.GetFileName(upload.FileName);
                        musicInfo.CoverArt = uploadFile.Replace(" ", "-");

                        var path = Path.Combine(Server.MapPath("~/CoverArts/"), upload.FileName + Path.GetExtension(uploadFile));
                        upload.SaveAs(path);
                    }
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileDetail fileDetail = new FileDetail()
                        {
                            FileName = fileName.Replace(" ", "-"),
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };

                        musicInfo.FileDetails = new List<FileDetail> { fileDetail };
                        var path = Path.Combine(Server.MapPath("~/MusicFiles/"), fileDetail.FileName);
                        file.SaveAs(path);
                    }


                    
                    db.MusicInfos.Add(musicInfo);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            

            return View(musicInfo);
        }

        // GET: MusicInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicInfo musicInfo = db.MusicInfos.Find(id);
            if (musicInfo == null)
            {
                return HttpNotFound();
            }
            return View(musicInfo);
        }

        // POST: MusicInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MusicInfoId,Title,Artist,CoverArt,Description")] MusicInfo musicInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musicInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musicInfo);
        }

        // GET: MusicInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicInfo musicInfo = db.MusicInfos.Find(id);
            if (musicInfo == null)
            {
                return HttpNotFound();
            }
            return View(musicInfo);
        }

        // POST: MusicInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MusicInfo musicInfo = db.MusicInfos.Find(id);
            db.MusicInfos.Remove(musicInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UploadSuccess(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicInfo musicInfo = db.MusicInfos.Include(m => m.FileDetails).SingleOrDefault(m => m.MusicInfoId == id);
            if (musicInfo == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
