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
            database.CreateTable<Check>();
            database.CreateTable<Task>();
            database.CreateTable<Lista>();
            database.CreateTable<User>();
        }

        public IEnumerable<Check> getCheckeds()
        {
            lock (locker)
            {
                return (from check in database.Table<Check>() select check).ToList();
            }
        }

        public Check getChecked (int id)
        {
            lock (locker)
            {
                return database.Table<Check>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveCheck(Check check)
        {
            lock (locker)
            {
                if (check.ID != 0)
                {
                    database.Update(check);
                    return check.ID;
                }
                else
                {
                    return database.Insert(check);
                }
            }
        }

        public int DeleteCheck(int id)
        {
            lock (locker)
            {
                return database.Delete<Check>(id);
            }
        }

        public IEnumerable<Task> getTasks()
        {
            lock (locker)
            {
                return (from task in database.Table<Task>() select task).ToList();
            }
        }

        public Task getTask(int id)
        {
            lock (locker)
            {
                return database.Table<Task>().FirstOrDefault(x => x.ID == id);
            }
        }
        public int SaveTask(Task task)
        {
            lock (locker)
            {
                if (task.ID != 0)
                {
                    database.Update(task);
                    return task.ID;
                }
                else
                {
                    return database.Insert(task);
                }
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
            lock (locker)
            {
                if (lista.ID != 0)
                {
                    database.Update(lista);
                    return lista.ID;
                }
                else
                {
                    return database.Insert(lista);
                }
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
            lock (locker)
            {
                if (user.ID != 0)
                {
                    database.Update(user);
                    return user.ID;
                }
                else
                {
                    return database.Insert(user);
                }
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
