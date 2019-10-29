using GoodToCode.Extensions;
using GoodToCode.Extensions.Configuration;
using GoodToCode.Extensions.Mathematics;
using GoodToCode.Extensions.Serialization;
using GoodToCode.Framework.Data;
using GoodToCode.Framework.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Person
{
    /// <summary>
    /// Test framework functionality
    /// </summary>
    /// <remarks></remarks>
    [TestClass()]
    public class PersonInfoTests
    {
        private static readonly object LockObject = new object();
        private static volatile List<Guid> _recycleBin = null;
        /// <summary>
        /// Singleton for recycle bin
        /// </summary>
        internal static List<Guid> RecycleBin
        {
            get
            {
                if (_recycleBin != null) return _recycleBin;
                lock (LockObject)
                {
                    if (_recycleBin == null)
                    {
                        _recycleBin = new List<Guid>();
                    }
                }
                return _recycleBin;
            }
        }

        List<PersonInfo> testEntities = new List<PersonInfo>()
        {
            new PersonInfo() {FirstName = "John", MiddleName = "Adam", LastName = "Doe", BirthDate = DateTime.Today.AddYears(Arithmetic.Random(2).Negate()) },
            new PersonInfo() {FirstName = "Jane", MiddleName = "Michelle", LastName = "Smith", BirthDate = DateTime.Today.AddYears(Arithmetic.Random(2).Negate()) },
            new PersonInfo() {FirstName = "Xi", MiddleName = "", LastName = "Ling", BirthDate = DateTime.Today.AddYears(Arithmetic.Random(2).Negate()) },
            new PersonInfo() {FirstName = "Juan", MiddleName = "", LastName = "Gomez", BirthDate = DateTime.Today.AddYears(Arithmetic.Random(2).Negate()) },
            new PersonInfo() {FirstName = "Maki", MiddleName = "", LastName = "Ishii", BirthDate = DateTime.Today.AddYears(Arithmetic.Random(2).Negate()) }
        };

        /// <summary>
        /// Initializes class before tests are ran
        /// </summary>
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            // Database is required for these tests
            var databaseAccess = false;
            var configuration = new ConfigurationManagerCore(ApplicationTypes.Native);
            using (var connection = new SqlConnection(configuration.ConnectionStringValue("DefaultConnection")))
            {
                databaseAccess = connection.CanOpen();
            }
            Assert.IsTrue(databaseAccess);
        }

        /// <summary>
        /// Person_PersonInfo
        /// </summary>
        [TestMethod()]
        public async Task Person_PersonInfo_Create()
        {
            var testEntity = new PersonInfo();
            var resultEntity = new PersonInfo();

            // Create should update original object, and pass back a fresh-from-db object
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            using (var writer = new StoredProcedureWriter<PersonInfo>(testEntity, new PersonInfoSPConfig()))
            {
                resultEntity = await writer.SaveAsync();
            }
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            // Object in db should match in-memory objects
            testEntity = new EntityReader<PersonInfo>().GetById(resultEntity.Id);
            Assert.IsTrue(!testEntity.IsNew);
            testEntity = new EntityReader<PersonInfo>().GetByKey(resultEntity.Key);
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.Id == resultEntity.Id);
            Assert.IsTrue(testEntity.Key == resultEntity.Key);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            PersonInfoTests.RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Core_Person_PersonInfo_Insert_Id
        /// </summary>
        /// <remarks></remarks>
        [TestMethod()]
        public async Task Person_PersonInfo_Create_Id()
        {
            var testEntity = new PersonInfo();
            var resultEntity = new PersonInfo();
            var oldId = Defaults.Integer;
            var oldKey = Defaults.Guid;
            var newId = Defaults.Integer;
            var newKey = Defaults.Guid;

            // Create and insert record
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            testEntity.Id = Defaults.Integer;
            testEntity.Key = Defaults.Guid;
            oldId = testEntity.Id;
            oldKey = testEntity.Key;
            Assert.IsTrue(testEntity.IsNew);
            Assert.IsTrue(testEntity.Id == Defaults.Integer);
            Assert.IsTrue(testEntity.Key == Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            // Do Insert and check passed entity and returned entity
            using (var writer = new StoredProcedureWriter<PersonInfo>(testEntity, new PersonInfoSPConfig()))
            {
                resultEntity = await writer.CreateAsync();
            }
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(!resultEntity.FailedRules.Any());

            // Pull from DB and retest
            testEntity = new EntityReader<PersonInfo>().GetById(resultEntity.Id);
            Assert.IsTrue(testEntity.IsNew == false);
            Assert.IsTrue(testEntity.Id != oldId);
            Assert.IsTrue(testEntity.Key != oldKey);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            // Cleanup
            RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Core_Person_PersonInfo_Insert_Key
        /// </summary>
        /// <remarks></remarks>
        [TestMethod()]
        public async Task Person_PersonInfo_Create_Key()
        {
            var testEntity = new PersonInfo();
            var resultEntity = new PersonInfo();
            var oldId = Defaults.Integer;
            var oldKey = Defaults.Guid;
            var newId = Defaults.Integer;
            var newKey = Defaults.Guid;

            // Create and insert record
            testEntity.Fill(testEntities[Arithmetic.Random(1, testEntities.Count)]);
            testEntity.Id = Defaults.Integer;
            testEntity.Key = Guid.NewGuid();
            oldId = testEntity.Id;
            oldKey = testEntity.Key;
            Assert.IsTrue(testEntity.IsNew);
            Assert.IsTrue(testEntity.Id == Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            // Do Insert and check passed entity and returned entity
            using (var writer = new StoredProcedureWriter<PersonInfo>(testEntity, new PersonInfoSPConfig()))
            {
                resultEntity = await writer.CreateAsync();
            }
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(!resultEntity.FailedRules.Any());

            // Pull from DB and retest
            testEntity = new EntityReader<PersonInfo>().GetById(resultEntity.Id);
            Assert.IsTrue(testEntity.IsNew == false);
            Assert.IsTrue(testEntity.Id != oldId);
            Assert.IsTrue(testEntity.Key == oldKey);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            // Cleanup
            RecycleBin.Add(testEntity.Key);
        }

        /// <summary>
        /// Person_PersonInfo
        /// </summary>
        [TestMethod()]
        public async Task Person_PersonInfo_Read()
        {
            var testEntity = new PersonInfo();
            var lastKey = Defaults.Guid;

            await Person_PersonInfo_Create();
            lastKey = PersonInfoTests.RecycleBin.LastOrDefault();

            testEntity = new EntityReader<PersonInfo>().GetByKey(lastKey);
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.CreatedDate.Date == DateTime.UtcNow.Date);
            Assert.IsTrue(!testEntity.FailedRules.Any());
        }

        /// <summary>
        /// Person_PersonInfo
        /// </summary>
        [TestMethod()]
        public async Task Person_PersonInfo_Update()
        {
            await Person_PersonInfo_Create();
            Guid lastKey = RecycleBin.LastOrDefault();

            PersonInfo testEntity = new EntityReader<PersonInfo>().GetByKey(lastKey);
            var originalId = testEntity.Id;
            var originalKey = testEntity.Key;
            var originalGender = testEntity.GenderCode;
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            var uniqueValue = Guid.NewGuid().ToString().Replace("-", "");
            testEntity.FirstName = uniqueValue;
            testEntity.GenderCode = GenderList.GetAll().Where(x => x.Item2 != originalGender).Select(y => y.Item2).FirstOrDefault();
            var resultEntity = new PersonInfo();
            using (var writer = new StoredProcedureWriter<PersonInfo>(testEntity, new PersonInfoSPConfig()))
            {
                resultEntity = await writer.SaveAsync();
            }
            Assert.IsTrue(!resultEntity.IsNew);
            Assert.IsTrue(resultEntity.Id != Defaults.Integer);
            Assert.IsTrue(resultEntity.Key != Defaults.Guid);
            Assert.IsTrue(resultEntity.GenderCode != originalGender);
            Assert.IsTrue(testEntity.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(testEntity.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(!testEntity.FailedRules.Any());
            testEntity = new EntityReader<PersonInfo>().GetByKey(originalKey);
            Assert.IsTrue(!testEntity.IsNew);
            Assert.IsTrue(testEntity.Id == resultEntity.Id && resultEntity.Id == originalId);
            Assert.IsTrue(testEntity.Key == resultEntity.Key && resultEntity.Key == originalKey);
            Assert.IsTrue(testEntity.GenderCode == resultEntity.GenderCode);
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());
        }

        /// <summary>
        /// Person_PersonInfo
        /// </summary>
        [TestMethod()]
        public async Task Person_PersonInfo_Delete()
        {
            var testEntity = new PersonInfo();
            var resultEntity = new PersonInfo();
            var lastKey = Defaults.Guid;
            var originalId = Defaults.Integer;
            var originalKey = Defaults.Guid;

            await Person_PersonInfo_Create();
            lastKey = PersonInfoTests.RecycleBin.LastOrDefault();

            testEntity = new EntityReader<PersonInfo>().GetByKey(lastKey);
            originalId = testEntity.Id;
            originalKey = testEntity.Key;
            Assert.IsTrue(testEntity.Id != Defaults.Integer);
            Assert.IsTrue(testEntity.Key != Defaults.Guid);
            Assert.IsTrue(testEntity.CreatedDate.Date == DateTime.UtcNow.Date);

            using (var writer = new StoredProcedureWriter<PersonInfo>(testEntity, new PersonInfoSPConfig()))
            {
                resultEntity = await writer.DeleteAsync();
            }
            Assert.IsTrue(resultEntity.IsNew);
            Assert.IsTrue(!resultEntity.FailedRules.Any());

            testEntity = new EntityReader<PersonInfo>().GetByKey(originalKey);
            Assert.IsTrue(testEntity.Id != originalId);
            Assert.IsTrue(testEntity.Key != originalKey);
            Assert.IsTrue(testEntity.IsNew);
            Assert.IsTrue(testEntity.Key == Defaults.Guid);
            Assert.IsTrue(!testEntity.FailedRules.Any());

            // Remove from RecycleBin (its already marked deleted)
            RecycleBin.Remove(lastKey);
        }


        [TestMethod()]
        public void Person_Person_Serialize()
        {
            var searchChar = "i";
            var originalObject = new PersonInfo() { FirstName = searchChar, LastName = searchChar };
            var resultObject = new PersonInfo();
            var resultString = Defaults.String;
            var serializer = new JsonSerializer<PersonInfo>();

            resultString = serializer.Serialize(originalObject);
            Assert.IsTrue(resultString != Defaults.String);
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.FirstName == searchChar);
            Assert.IsTrue(resultObject.LastName == searchChar);
        }


        [TestMethod()]
        public void Person_Person_ISO8601()
        {
            var searchChar = "i";
            var serializer = new JsonSerializer<PersonInfo>();
            var resultObject = new PersonInfo();
            var resultString = Defaults.String;
            var zeroTime = Defaults.Date;
            var testMS = new DateTime(1983, 12, 9, 5, 10, 20, 3);
            var noMS = new DateTime(1983, 12, 9, 5, 10, 20, 000);

            //Explicitly set
            serializer.DateTimeFormatString = new DateTimeFormat(DateTimeExtension.Formats.ISO8601) { DateTimeStyles = System.Globalization.DateTimeStyles.RoundtripKind };

            // 1 digit millisecond
            resultObject = new PersonInfo() { FirstName = searchChar, LastName = searchChar, BirthDate = testMS, CreatedDate = testMS, ModifiedDate = testMS };
            resultString = serializer.Serialize(resultObject);
            Assert.IsTrue(resultString != Defaults.String);
            Assert.IsTrue(resultString.Contains(testMS.ToString(DateTimeExtension.Formats.ISO8601)));
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.FirstName == searchChar && resultObject.LastName == searchChar);
            Assert.IsTrue(resultObject.BirthDate == noMS && resultObject.CreatedDate == noMS && resultObject.ModifiedDate == noMS);

            // 2 digit millisecond
            testMS.AddMilliseconds(-testMS.Millisecond);
            testMS.AddMilliseconds(30);
            resultObject = new PersonInfo() { FirstName = searchChar, LastName = searchChar, BirthDate = testMS, CreatedDate = testMS, ModifiedDate = testMS };
            resultString = serializer.Serialize(resultObject);
            Assert.IsTrue(resultString != Defaults.String);
            Assert.IsTrue(resultString.Contains(testMS.ToString(DateTimeExtension.Formats.ISO8601)));
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.FirstName == searchChar && resultObject.LastName == searchChar);
            Assert.IsTrue(resultObject.BirthDate == noMS && resultObject.CreatedDate == noMS && resultObject.ModifiedDate == noMS);

            // 3 digit millisecond
            testMS.AddMilliseconds(-testMS.Millisecond);
            testMS.AddMilliseconds(300);
            resultObject = new PersonInfo() { FirstName = searchChar, LastName = searchChar, BirthDate = testMS, CreatedDate = testMS, ModifiedDate = testMS };
            resultString = serializer.Serialize(resultObject);
            Assert.IsTrue(resultString != Defaults.String);
            Assert.IsTrue(resultString.Contains(testMS.ToString(DateTimeExtension.Formats.ISO8601)));
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.FirstName == searchChar && resultObject.LastName == searchChar);
            Assert.IsTrue(resultObject.BirthDate == noMS && resultObject.CreatedDate == noMS && resultObject.ModifiedDate == noMS);

            // Mixed
            resultObject = new PersonInfo() { FirstName = searchChar, LastName = searchChar, BirthDate = testMS, CreatedDate = new DateTime(1983, 12, 9, 5, 10, 20, 0), ModifiedDate = new DateTime(1983, 12, 9, 5, 10, 20, 0) };
            resultString = serializer.Serialize(resultObject);
            Assert.IsTrue(resultString != Defaults.String);
            Assert.IsTrue(resultString.Contains(testMS.ToString(DateTimeExtension.Formats.ISO8601)));
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.FirstName == searchChar && resultObject.LastName == searchChar);
            Assert.IsTrue(resultObject.BirthDate == noMS && resultObject.CreatedDate == noMS && resultObject.ModifiedDate == noMS);
        }

        [TestMethod()]
        public void Person_Person_ISO8601F()
        {
            var searchChar = "i";
            var serializer = new JsonSerializer<PersonInfo>();
            var resultObject = new PersonInfo();
            var resultString = Defaults.String;
            var zeroTime = Defaults.Date;
            var testMS = new DateTime(1983, 12, 9, 5, 10, 20, 3);

            //Explicitly set
            serializer.DateTimeFormatString = new DateTimeFormat(DateTimeExtension.Formats.ISO8601F) { DateTimeStyles = System.Globalization.DateTimeStyles.RoundtripKind };

            // 1 digit millisecond
            resultObject = new PersonInfo() { FirstName = searchChar, LastName = searchChar, BirthDate = testMS, CreatedDate = testMS, ModifiedDate = testMS };
            resultString = serializer.Serialize(resultObject);
            Assert.IsTrue(resultString != Defaults.String);
            Assert.IsTrue(resultString.Contains(testMS.ToString(DateTimeExtension.Formats.ISO8601F)));
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.FirstName == searchChar && resultObject.LastName == searchChar);
            Assert.IsTrue(resultObject.BirthDate == testMS && resultObject.CreatedDate == testMS && resultObject.ModifiedDate == testMS);
            Assert.IsTrue(resultObject.BirthDate.Millisecond.ToString().Length == 1);

            // 2 digit millisecond
            testMS = testMS.AddMilliseconds(-testMS.Millisecond).AddMilliseconds(30);
            resultObject = new PersonInfo() { FirstName = searchChar, LastName = searchChar, BirthDate = testMS, CreatedDate = testMS, ModifiedDate = testMS };
            resultString = serializer.Serialize(resultObject);
            Assert.IsTrue(resultString != Defaults.String);
            Assert.IsTrue(resultString.Contains(testMS.ToString(DateTimeExtension.Formats.ISO8601F)));
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.FirstName == searchChar && resultObject.LastName == searchChar);
            Assert.IsTrue(resultObject.BirthDate == testMS && resultObject.CreatedDate == testMS && resultObject.ModifiedDate == testMS);
            Assert.IsTrue(resultObject.BirthDate.Millisecond.ToString().Length == 2);

            // 3 digit millisecond
            testMS = testMS.AddMilliseconds(-testMS.Millisecond).AddMilliseconds(300);
            resultObject = new PersonInfo() { FirstName = searchChar, LastName = searchChar, BirthDate = testMS, CreatedDate = testMS, ModifiedDate = testMS };
            resultString = serializer.Serialize(resultObject);
            Assert.IsTrue(resultString != Defaults.String);
            Assert.IsTrue(resultString.Contains(testMS.ToString(DateTimeExtension.Formats.ISO8601F)));
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.FirstName == searchChar && resultObject.LastName == searchChar);
            Assert.IsTrue(resultObject.BirthDate == testMS && resultObject.CreatedDate == testMS && resultObject.ModifiedDate == testMS);
            Assert.IsTrue(resultObject.BirthDate.Millisecond.ToString().Length == 3);

            // Mixed
            resultObject = new PersonInfo() { FirstName = searchChar, LastName = searchChar, BirthDate = testMS.AddMilliseconds(-testMS.Millisecond), CreatedDate = testMS.AddMilliseconds(-testMS.Millisecond).AddMilliseconds(30), ModifiedDate = testMS.AddMilliseconds(-testMS.Millisecond).AddMilliseconds(300) };
            resultString = serializer.Serialize(resultObject);
            Assert.IsTrue(resultString != Defaults.String);
            Assert.IsTrue(resultString.Contains(testMS.ToString(DateTimeExtension.Formats.ISO8601F)));
            resultObject = serializer.Deserialize(resultString);
            Assert.IsTrue(resultObject.FirstName == searchChar && resultObject.LastName == searchChar);
            Assert.IsTrue(resultObject.BirthDate == testMS.AddMilliseconds(-testMS.Millisecond) && resultObject.CreatedDate == testMS.AddMilliseconds(-testMS.Millisecond).AddMilliseconds(30) && resultObject.ModifiedDate == testMS.AddMilliseconds(-testMS.Millisecond).AddMilliseconds(300));
            Assert.IsTrue(resultObject.BirthDate.Millisecond.ToString().Length == 1);
        }

        // Test combination of DateTime Json formats, to ensure behavior is consistent
        public const string Person_HHMMSS = "{\"BusinessRules\":[],\"FailedRules\":[],\"CreatedDate\":\"1900-01-01T00:00:00\",\"Id\":-1,\"Key\":\"00000000-0000-0000-0000-000000000000\",\"ModifiedDate\":\"1900-01-01T00:00:00\",\"Status\":0,\"BirthDate\":\"1900-01-01T00:00:00\",\"PersonTypeKey\":\"bf3797ee-06a5-47f2-9016-369beb21d944\",\"FirstName\":\"i\",\"GenderID\":-1,\"LastName\":\"i\",\"MiddleName\":\"\"}";
        public const string Person_HHMMSSfff = "{\"BusinessRules\":[],\"FailedRules\":[],\"CreatedDate\":\"2017-03-26T20:57:10.411\",\"Id\":-1,\"Key\":\"00000000-0000-0000-0000-000000000000\",\"ModifiedDate\":\"2017-03-26T20:57:10.411\",\"Status\":0,\"BirthDate\":\"2017-03-26T20:57:10.411\",\"PersonTypeKey\":\"bf3797ee-06a5-47f2-9016-369beb21d944\",\"FirstName\":\"i\",\"GenderID\":-1,\"LastName\":\"i\",\"MiddleName\":\"\"}";
        public const string PersonSearch_HHMMSS = "{\"BusinessRules\":[],\"FailedRules\":[],\"CreatedDate\":\"1900-01-01T00:00:00\",\"Id\":-1,\"Key\":\"00000000-0000-0000-0000-000000000000\",\"ModifiedDate\":\"1900-01-01T00:00:00\",\"Status\":0,\"BirthDate\":\"1900-01-01T00:00:00\",\"PersonTypeKey\":\"bf3797ee-06a5-47f2-9016-369beb21d944\",\"FirstName\":\"i\",\"GenderID\":-1,\"LastName\":\"i\",\"MiddleName\":\"\",\"Results\":[]}";
        public const string PersonSearchResults_HHMMSS = "{\"BusinessRules\":[],\"FailedRules\":[],\"CreatedDate\":\"1900-01-01T00:00:00\",\"Id\":-1,\"Key\":\"00000000-0000-0000-0000-000000000000\",\"ModifiedDate\":\"1900-01-01T00:00:00\",\"Status\":0,\"BirthDate\":\"1900-01-01T00:00:00\",\"PersonTypeKey\":\"bf3797ee-06a5-47f2-9016-369beb21d944\",\"FirstName\":\"i\",\"GenderID\":-1,\"LastName\":\"i\",\"MiddleName\":\"\",\"Results\":[{\"BusinessRules\":[],\"FailedRules\":[],\"CreatedDate\":\"2017-03-27T00:48:58\",\"Id\":35,\"Key\":\"abc80489-53b3-4f6d-bdc2-135e569885c5\",\"ModifiedDate\":\"2017-03-27T00:48:58\",\"Status\":0,\"BirthDate\":\"1973-06-30T00:00:00\",\"PersonTypeKey\":\"51a84ce1-4846-4a71-971a-cb610eeb4848\",\"FirstName\":\"Maki\",\"GenderID\":-1,\"LastName\":\"Ishii\",\"MiddleName\":\"L\"},{\"BusinessRules\":[],\"FailedRules\":[],\"CreatedDate\":\"2017-03-27T01:25:46\",\"Id\":37,\"Key\":\"e55fe6a3-dace-4b25-b876-1c516315f687\",\"ModifiedDate\":\"2017-03-27T01:25:46\",\"Status\":0,\"BirthDate\":\"1988-03-26T00:00:00\",\"PersonTypeKey\":\"bf3797ee-06a5-47f2-9016-369beb21d944\",\"FirstName\":\"Xi\",\"GenderID\":-1,\"LastName\":\"Ling\",\"MiddleName\":\"\"},{\"BusinessRules\":[],\"FailedRules\":[],\"CreatedDate\":\"2017-03-27T01:27:12\",\"Id\":39,\"Key\":\"7fae8812-7de3-4d9f-9796-9c83dd437f80\",\"ModifiedDate\":\"2017-03-27T01:27:12\",\"Status\":0,\"BirthDate\":\"1997-03-26T00:00:00\",\"PersonTypeKey\":\"bf3797ee-06a5-47f2-9016-369beb21d944\",\"FirstName\":\"Maki\",\"GenderID\":-1,\"LastName\":\"Ishii\",\"MiddleName\":\"\"},{\"BusinessRules\":[],\"FailedRules\":[],\"CreatedDate\":\"2017-03-27T01:32:45\",\"Id\":40,\"Key\":\"58da2563-6972-49e9-9974-bb8ab8eaaf9b\",\"ModifiedDate\":\"2017-03-27T01:32:45\",\"Status\":0,\"BirthDate\":\"1943-03-26T00:00:00\",\"PersonTypeKey\":\"bf3797ee-06a5-47f2-9016-369beb21d944\",\"FirstName\":\"Maki\",\"GenderID\":-1,\"LastName\":\"Ishii\",\"MiddleName\":\"\"},{\"BusinessRules\":[],\"FailedRules\":[],\"CreatedDate\":\"2017-03-27T02:14:36\",\"Id\":42,\"Key\":\"c3e092c7-3e3b-4132-bc29-55c2ef295409\",\"ModifiedDate\":\"2017-03-27T02:14:36\",\"Status\":0,\"BirthDate\":\"1976-03-26T00:00:00\",\"PersonTypeKey\":\"00000000-0000-0000-0000-000000000000\",\"FirstName\":\"Xi\",\"GenderID\":-1,\"LastName\":\"Ling\",\"MiddleName\":\"\"},{\"BusinessRules\":[],\"FailedRules\":[],\"CreatedDate\":\"2017-03-27T02:34:22\",\"Id\":43,\"Key\":\"8569368a-3e1d-430a-9e22-c8d03c35eb5b\",\"ModifiedDate\":\"2017-03-27T02:34:22\",\"Status\":0,\"BirthDate\":\"1932-03-26T00:00:00\",\"PersonTypeKey\":\"bf3797ee-06a5-47f2-9016-369beb21d944\",\"FirstName\":\"Xi\",\"GenderID\":-1,\"LastName\":\"Ling\",\"MiddleName\":\"\"},{\"BusinessRules\":[],\"FailedRules\":[],\"CreatedDate\":\"2017-03-27T02:34:22\",\"Id\":44,\"Key\":\"bcc2cd37-3cc2-4ae8-aa83-ddaf48a36c41\",\"ModifiedDate\":\"2017-03-27T02:34:22\",\"Status\":0,\"BirthDate\":\"1958-03-26T00:00:00\",\"PersonTypeKey\":\"bf3797ee-06a5-47f2-9016-369beb21d944\",\"FirstName\":\"Xi\",\"GenderID\":-1,\"LastName\":\"Ling\",\"MiddleName\":\"\"},{\"BusinessRules\":[],\"FailedRules\":[],\"CreatedDate\":\"2017-03-27T15:30:18\",\"Id\":48,\"Key\":\"a447babf-159a-4799-98a0-60777d2b4d24\",\"ModifiedDate\":\"2017-03-27T15:30:18\",\"Status\":0,\"BirthDate\":\"2003-03-27T00:00:00\",\"PersonTypeKey\":\"bf3797ee-06a5-47f2-9016-369beb21d944\",\"FirstName\":\"Maki\",\"GenderID\":-1,\"LastName\":\"Ishii\",\"MiddleName\":\"\"}]}";
        public const string PersonSearchResults_HHMMSSfff = "{\"BusinessRules\":[],\"FailedRules\":[],\"CreatedDate\":\"1900-01-01T00:00:00.000\",\"Id\":-1,\"Key\":\"00000000-0000-0000-0000-000000000000\",\"ModifiedDate\":\"1900-01-01T00:00:00.000\",\"Status\":0,\"BirthDate\":\"1900-01-01T00:00:00.000\",\"PersonTypeKey\":\"bf3797ee-06a5-47f2-9016-369beb21d944\",\"FirstName\":\"i\",\"GenderID\":-1,\"LastName\":\"i\",\"MiddleName\":\"\",\"Results\":[{\"BusinessRules\":[],\"FailedRules\":[],\"CreatedDate\":\"2017-03-27T00:48:58.058\",\"Id\":35,\"Key\":\"abc80489-53b3-4f6d-bdc2-135e569885c5\",\"ModifiedDate\":\"2017-03-27T00:48:58.058\",\"Status\":0,\"BirthDate\":\"1973-06-30T00:00:00.000\",\"PersonTypeKey\":\"51a84ce1-4846-4a71-971a-cb610eeb4848\",\"FirstName\":\"Maki\",\"GenderID\":-1,\"LastName\":\"Ishii\",\"MiddleName\":\"L\"},{\"BusinessRules\":[],\"FailedRules\":[],\"CreatedDate\":\"2017-03-27T01:25:46.046\",\"Id\":37,\"Key\":\"e55fe6a3-dace-4b25-b876-1c516315f687\",\"ModifiedDate\":\"2017-03-27T01:25:46.046\",\"Status\":0,\"BirthDate\":\"1988-03-26T00:00:00.000\",\"PersonTypeKey\":\"bf3797ee-06a5-47f2-9016-369beb21d944\",\"FirstName\":\"Xi\",\"GenderID\":-1,\"LastName\":\"Ling\",\"MiddleName\":\"\"}]}";

        /// <summary>
        /// Cleanup all data
        /// </summary>
        [ClassCleanup()]
        public static async Task Cleanup()
        {
            var reader = new EntityReader<PersonInfo>();
            var toDelete = new PersonInfo();

            foreach (Guid item in RecycleBin)
            {
                toDelete = reader.GetAll().Where(x => x.Key == item).FirstOrDefaultSafe();
                using (var db = new StoredProcedureWriter<PersonInfo>(toDelete, new PersonInfoSPConfig()))
                {
                    await db.DeleteAsync();
                }
            }
        }
    }
}