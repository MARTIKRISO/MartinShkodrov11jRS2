using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using BusinessLayer;

namespace IhaveNoIdeaWhatImDoingButItWorks
{
    [TestClass]
    public class UserUnitTests
    {
        UserContext context;
        User ElUsero;
        
        [TestInitialize]
        public void Setup()
        {
            var __context = new ExamDBContext();
            var _context = new UserContext(__context);
            this.context = _context;

            User user = new User(0, "Spas", "Tzilkov", 21, "spastz", "123456", "spas@poshta.bg");
            ElUsero = user;
        }
        [TestCleanup]
        public void CleanUp()
        {
            //Deletion
            context.Delete(ElUsero);
            //Creation
            context.Create(ElUsero);
        }


        [TestMethod]
        public void CreateTest()
        {                  
            //Asserting 
            Assert.IsNotNull(context.Read(0));
        }
        [TestMethod]
        public void ReadTest()
        {          
            //Doing
            var data = context.Read(0);

            //Doing 
            Assert.AreEqual(21, data.age);
        }
        [TestMethod]
        public void UpdateTest()
        {
            //Doing
            var newuser = new User(0, "Spos", "Tzolkov", 22, "spostz", "1234", "spos@poshta.bg");
            context.Update(newuser);

            //Asserting 
            Assert.AreEqual("Spos", context.Read(0).fname);
        }
        [TestMethod]
        public void DeleteTest()
        {     
            //Doing 
            context.Delete(0);
            
            Assert.IsNull(context.Read(0));
        }
        [TestMethod]
        public void ReadAllTest()
        {
            //Doing 
            Assert.IsNotNull(context.ReadAll());
        }
    }
}