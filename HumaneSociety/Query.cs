using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {
        public static Client GetClient(string userName, string password)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var clientData = db.Clients.Where(c => c.userName == userName).Where(c => c.pass == password).First();
            return clientData;
        }
        public static IQueryable<ClientAnimalJunction> GetUserAdoptionStatus(Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var clientData = db.Clients.Where(c => c.ID == client.ID).First();
            var junctionData = db.ClientAnimalJunctions.Where(c => client.ID == clientData.ID); 
            return junctionData;
        }
        public static Animal GetAnimalByID(int iD)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var animalData = db.Animals.Where(c => c.ID == iD).First();
            return animalData;
        }
        public static void Adopt(object animal, Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

            var animalData = db.Animals.Where(a => a == animal).First();
            var clientData = db.Clients.Where(c => c.ID == client.ID).First();

            var clientJunctionData = db.ClientAnimalJunctions.Where(c => c.client == clientData.ID).Where(cj => cj.animal == animalData.ID).First();

            clientJunctionData.approvalStatus = "pending";
            animalData.adoptionStatus = "pending";
            db.SubmitChanges();
        }
        public static IQueryable<Client> RetrieveClients()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var clientData = from c in db.Clients select c;
            return clientData;
        }
        public static IQueryable<USState> GetStates()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var stateData = from us in db.USStates select us;
            return stateData;
        }

        public static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int state)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            Client newClient = new Client();

            newClient.firstName = firstName;
            newClient.lastName = lastName;
            newClient.userName = username;
            newClient.pass = password;
            newClient.email = email;
            var addressJunction = db.UserAddresses.Where(c => c.ID == newClient.ID).First();
            addressJunction.addessLine1 = streetAddress;
            addressJunction.zipcode = zipCode;
            addressJunction.USStates = state;
            newClient.userAddress = addressJunction.ID;

            db.Clients.InsertOnSubmit(newClient);
            db.SubmitChanges();
           
        }

        public static void UpdateClient(Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var clientData = db.Clients.Where(c => c.ID == client.ID).First();
            clientData = client;
            db.SubmitChanges();
        }
        public static void UpdateUsername(Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var clientData = db.Clients.Where(c => c.ID == client.ID).First();
            clientData.userName = client.userName;
            db.SubmitChanges();
        }

        public static void UpdateEmail(Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var clientData = db.Clients.Where(c => c.ID == client.ID).First();
            clientData.email = client.email;
            db.SubmitChanges();
        }

        public static void UpdateAddress(Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var clientData = db.Clients.Where(c => c.ID == client.ID).First();
            clientData.userAddress = client.userAddress;
            db.SubmitChanges();
        }

        public static void UpdateFirstName(Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var clientData = db.Clients.Where(c => c.ID == client.ID).First();
            clientData.firstName = client.firstName;
            db.SubmitChanges();
        }

        public static void UpdateLastName(Client client)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var clientData = db.Clients.Where(c => c.ID == client.ID).First();
            clientData.lastName = client.lastName;
            db.SubmitChanges();
        }

        internal static void RunEmployeeQueries(Employee employee, string v)
        {
        }

        public static IQueryable<ClientAnimalJunction> GetPendingAdoptions()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var pendingAdoptions = db.ClientAnimalJunctions.Where(pa => pa.approvalStatus == "pending");
            return pendingAdoptions;
        }

        public static void UpdateAdoption(bool v, ClientAnimalJunction clientAnimalJunction)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            var animalAdopted = db.Animals.Where(c => c.ID == clientAnimalJunction.animal).First();
            if (v == true)
            {
                animalAdopted.adoptionStatus = "adopted";
                clientAnimalJunction.approvalStatus = "adopted";
            }
            else if (v == false)
            {
                clientAnimalJunction.approvalStatus = "not adopted";
                animalAdopted.adoptionStatus = "not adopted";
            }
            db.SubmitChanges();

        }

        internal static object GetShots(Animal animal)
        {
            throw new NotImplementedException();
        }

        internal static void UpdateShot(string v, Animal animal)
        {
            throw new NotImplementedException();
        }

        internal static void EnterUpdate(Animal animal, Dictionary<int, string> updates)
        {
            throw new NotImplementedException();
        }

        internal static void RemoveAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        internal static int? GetBreed()
        {
            throw new NotImplementedException();
        }

        internal static int? GetDiet()
        {
            throw new NotImplementedException();
        }

        internal static int? GetLocation()
        {
            throw new NotImplementedException();
        }

        internal static void AddAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        internal static Employee EmployeeLogin(string userName, string password)
        {
            throw new NotImplementedException();
        }

        internal static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            throw new NotImplementedException();
        }

        internal static void AddUsernameAndPassword(Employee employee)
        {
            throw new NotImplementedException();
        }

        internal static bool CheckEmployeeUserNameExist(string username)
        {
            throw new NotImplementedException();
        }
    }
}
