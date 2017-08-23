using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<User> GetUserList()
        {
            using (UserEntities entities = new UserEntities())
            {
                return entities.User.ToList();
            }
        }
        public User GetUserById(string id)
        {
            try
            {
                int UserId = Convert.ToInt32(id);
                using (UserEntities entities = new UserEntities())
                {
                    return entities.User.SingleOrDefault(User => User.id == UserId);
                }
            }
            catch
            {
                throw new FaultException("Something went wrong");
            }
        }
        public bool IsValid(string em, string ps)
        {
            try
            {
                using (UserEntities entities = new UserEntities())
                {
                    var query = (from c in entities.User
                                 where c.email == em && c.password == ps
                                 select c).Any();
                    return query;
                }
            }
            catch
            {
                throw new FaultException("Something went wrong");
            }
        }
        public void AddUser(string Name, string Email, string Password)
        {
            using (UserEntities entities = new UserEntities())
            {
                try
                {
                    User user = new User { name = Name, email = Email, password = Password };
                    entities.User.Add(user);
                    entities.SaveChanges();
                }
                catch
                {
                    throw new FaultException("Something went wrong");
                }
                
            }
        }
        //take all class on function
        public void UpdateUser(UserComposite usr)
        {
            try
            {
                int UserID = Convert.ToInt32(usr.Id);
                using (UserEntities entities = new UserEntities())
                {
                    User wow = entities.User.SingleOrDefault(b => b.id == UserID);
                    wow.name = usr.Name;
                    wow.email = usr.Email;
                    wow.password = usr.Password;
                    entities.SaveChanges();
                }
            }
            catch
            {
                throw new FaultException("Something went wrong");
            }
        }
        public void DeleteUser(string id)
        {
            try
            {
                int UserID = Convert.ToInt32(id);
                using (UserEntities entities = new UserEntities())
                {
                    User user = entities.User.SingleOrDefault(b => b.id == UserID);
                    entities.User.Remove(user);
                }
            }
            catch
            {
                throw new FaultException("Something went wrong");
            }
        }

        
    }
}
