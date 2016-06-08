using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;
using HAVO.Models;

namespace HAVO.Data
{
    public class DatabaseHAVO
    {

        static object locker = new object();

        SQLiteConnection database;

        string DatabasePath
        {
            get
            {
                var sqliteFilename = "HAVOSQLite.db3";
#if __IOS__
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
				var path = Path.Combine(libraryPath, sqliteFilename);
#else
#if __ANDROID__
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                var path = Path.Combine(documentsPath, sqliteFilename);
#else
				// WinPhone
				var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);;
#endif
#endif
                return path;
            }
        }

        public DatabaseHAVO()
        {
            database = new SQLiteConnection(DatabasePath, true);
            database.CreateTable<Evaluation>();
            database.CreateTable<Task>();
            database.CreateTable<Lista>();
            database.CreateTable<User>();
        }

        public IEnumerable<Evaluation> getCheckeds()
        {
            lock (locker)
            {
                return (from check in database.Table<Evaluation>() select check).ToList();
            }
        }

        public Evaluation getChecked (int id)
        {
            lock (locker)
            {
                return database.Table<Evaluation>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveCheck(Evaluation check)
        {
            int id;
            lock (locker)
            {
                if (check.ID != 0)
                {
                    database.Update(check);
                    id = check.ID;
                }
                else
                {
                    id =  database.Insert(check);
                }
                return id;
            }
        }

        public int DeleteCheck(int id)
        {
            lock (locker)
            {
                return database.Delete<Evaluation>(id);
            }
        }

        public IEnumerable<Task> getTasks(int listaId)
        {
            lock (locker)
            {
                return (from task in database.Table<Task>() where task.ListID == listaId select task).ToList();
            }
        }

        public Task getTask(int taskId)
        {
            lock (locker)
            {
                return database.Table<Task>().FirstOrDefault(x => x.ID == taskId);
            }
        }
        public int SaveTask(Task task)
        {
            int id;
            lock (locker)
            {
                if (task.ID != 0)
                {
                    database.Update(task);
                    id = task.ID;
                }
                else
                {
                    id = database.Insert(task);
                }
                return id;
            }
        }

        public int DeleteTask(int id)
        {
            lock (locker)
            {
                return database.Delete<Task>(id);
            }
        }

        public IEnumerable<Lista> getListas()
        {
            lock (locker)
            {
                return (from listas in database.Table<Lista>() select listas).ToList();
            }
        }

        public Lista getLista(int id)
        {
            lock (locker)
            {
                return database.Table<Lista>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveLista(Lista lista)
        {
            int id;
            lock (locker)
            {
                if (lista.ID != 0)
                {
                    database.Update(lista);
                    id = lista.ID;
                }
                else
                {
                    id = database.Insert(lista);
                }
                return id;
            }
        }

        public int DeleteLista(int id)
        {
            lock (locker)
            {
                return database.Delete<Lista>(id);
            }
        }

        public IEnumerable<User> getUsers()
        {
            lock (locker)
            {
                return (from users in database.Table<User>() select users).ToList();
            }
        }

        public User getUser(int id)
        {
            lock (locker)
            {
                return database.Table<User>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveUser(User user)
        {
            int id;
            lock (locker)
            {
                if (user.ID != 0)
                {
                    database.Update(user);
                    id = user.ID;
                }
                else
                {
                    id = database.Insert(user);
                }
                return id;
            }
        }

        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }
    }
}
