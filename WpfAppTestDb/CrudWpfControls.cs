﻿using MyLibDb;
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
        public static void AddPublisher(string name) {
            using (_TestContext db = new _TestContext()) {
                Publisher pub = new Publisher();
                pub.Name = name;
                db.Publishers.Add(pub);
                db.SaveChanges();
            }
        }

        public static void tempDel(object t)
        {
           if(t is Publisher p)
            {
                                
                int i = p.Id;
                MessageBox.Show("Pub - "+i.ToString());
                using (_TestContext db = new _TestContext())
                {
                    Publisher pubDel = db.Publishers.Find(p.Id);
                    db.Publishers.Remove(pubDel);
                    db.SaveChanges();

                }
                return;
            }
           if(t is Developer)
            {
                MessageBox.Show("Dev");
                return;
            }


           

        }

        public static void RemovePublisher(int id) {
            using (_TestContext db = new _TestContext()) {
                Publisher publisher = db.Publishers.Find(id);
                db.Publishers.Remove(publisher);
                db.SaveChanges();
            }
        }

        public static void EditPublisher(int id, string newName) {
            using (_TestContext db = new _TestContext()) {
                Publisher publisher = db.Publishers.Find(id);
                publisher.Name = newName;
                db.SaveChanges();
                MessageBox.Show("done uspeshno");
            
            }
        }
    

    }
}
