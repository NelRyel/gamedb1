using MyLibDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppTestDb {
    public static class CrudWpfControls {

        public static bool PubCompare(string name) {
            using (_TestContext db = new _TestContext()) {
                List<Publisher> publisher = db.Publishers.ToList();
                for (int i = 0; i < publisher.Count; i++) {
                    if (name == publisher[i].Name) {
                        return false;
                    }
                }
                return true;
            }
        
        }
        public static bool DevCompare(string name) {
            using (_TestContext db = new _TestContext()) {
                List<Developer> dev = db.Developers.ToList();
                for (int i = 0; i < dev.Count; i++) {
                    if (name == dev[i].Name) {
                        return false;
                    }
                }
                return true;
            }

        }


        public static void AddPublisher(string name) {
            using (_TestContext db = new _TestContext()) {
                Publisher pub = new Publisher();
                pub.Name = name;
                db.Publishers.Add(pub);
                db.SaveChanges();
            }
        }

        public static void AddDeveloper(string name) {
            using (_TestContext db = new _TestContext()) {
                Developer dev = new Developer();
                dev.Name = name;
                db.Developers.Add(dev);
                db.SaveChanges();
            }
        }

        public static void tempDel(object t)
        {
            using (_TestContext db = new _TestContext()) {
                try {
                    if (t is Publisher p) {

                        int i = p.Id;
                        MessageBox.Show("Pub - " + i.ToString());
                       
                        Publisher pubDel = db.Publishers.Find(p.Id);
                        db.Publishers.Remove(pubDel);
                        db.SaveChanges();
                        return;
                    }
                    if (t is Developer d) {
                        int i = d.Id;
                        MessageBox.Show("Dev - " + i.ToString());
                        Developer dd = db.Developers.Find(d.Id);
                        db.Developers.Remove(dd);
                        db.SaveChanges();
                        return;
                    }
                    if (t is Genre g) {
                        int i = g.Id;
                        MessageBox.Show("Genre - " + i.ToString());
                        Genre gg = db.Genres.Find(g.Id);
                        db.Genres.Remove(gg);
                        db.SaveChanges();
                        return;
                    }
                }
                catch (Exception e) {
                    MessageBox.Show(e.ToString());
                }




            }
        }

        //public static void RemovePublisher(int id) {
        //    using (_TestContext db = new _TestContext()) {
        //        Publisher publisher = db.Publishers.Find(id);
        //        db.Publishers.Remove(publisher);
        //        db.SaveChanges();
        //    }
        //}

        public static void EditPublisher(int id, string newName) {
            using (_TestContext db = new _TestContext()) {
                Publisher publisher = db.Publishers.Find(id);
                publisher.Name = newName;
                db.SaveChanges();
                MessageBox.Show("done uspeshno");
            
            }
        }

        public static void EditDev(int id, string newName) {
            using (_TestContext db = new _TestContext()) {
                Developer developer = db.Developers.Find(id);
                developer.Name = newName;
                db.SaveChanges();
                MessageBox.Show("done uspeshno");

            }
        }


    }
}
