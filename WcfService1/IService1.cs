using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate = "users", ResponseFormat  = WebMessageFormat.Json)]
        List<User> GetUserList();

        [OperationContract]
        [WebGet(UriTemplate = "user/{id}", ResponseFormat = WebMessageFormat.Json)]
        User GetUserById(string id);

        [OperationContract]
        [WebGet(UriTemplate = "user/{email}/{pass}", ResponseFormat = WebMessageFormat.Json)]
        bool IsValid(string email, string pass);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "user/add/{name}/{email}/{pass}", ResponseFormat = WebMessageFormat.Json)]
        void AddUser(string name, string email, string pass);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "user/update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void UpdateUser(UserComposite usr);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "user/delete/{id}", ResponseFormat = WebMessageFormat.Json)]
        void DeleteUser(string id);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class UserComposite
    {
        private int userID;
        private string userName;
        private string userEmail;
        private string userPass;
        string stringValue = "Hello ";

        [DataMember(Name ="id")]
        public int Id
        {
            get { return userID; }
            set { userID = value; }
        }

        [DataMember(Name ="name")]
        public string Name
        {
            get { return userName; }
            set { userName = value; }
        }
        [DataMember(Name = "email")]
        public string Email
        {
            get { return userEmail; }
            set { userEmail = value; }
        }
        [DataMember(Name = "Password")]
        public string Password
        {
            get { return userPass; }
            set { userPass = value; }
        }
    }
}
