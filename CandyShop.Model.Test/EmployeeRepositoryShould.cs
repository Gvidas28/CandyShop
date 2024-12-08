using CandyShop.Model.Entities;
using CandyShop.Model.Repositories;
using MySql.Data.MySqlClient;

namespace CandyShop.Model.Test
{
    public class EmployeeRepositoryShould
    {
        [Fact]
        public void ReturnEmployeeByUsername()
        {
            var mySql = new Mock<ISqlExecutor>();
            var dbReader = new Mock<ISqlReader>();
            var expectedQuery = @$"
                SELECT `ID`, `Username`, `Password`, `Email`, `Name`, `LastName`, `StartDate`, `Sector`
                FROM `employees`
                WHERE `Username` = ?username";

            var IdColumn = 0;
            var someId = "2";

            var UsernameColumn = 1;
            var someUsername = "aUsername";

            var PasswordColumn = 2;
            var somePassord = "aPassword";

            var EmailColumn = 3;
            var someEmail = "aEmail";

            var NameColumn = 4;
            var someName = "aName";

            var LastNameColumn = 5;
            var someLastName = "aLastName";

            var StartDateColumn = 6;
            var someStartDate = "2021-02-03";

            var SectorColumn = 7;
            var someSector = "aSector";

            var expectedEmployee = new Employee()
            {
                ID = int.Parse(someId),
                Username = someUsername,
                Password = somePassord,
                Email = someEmail,
                Name = someName,
                LastName = someLastName,
                StartDate = DateTime.Parse(someStartDate),
                Sector = someSector
            };

            var expectedParams = new Dictionary<string, object> { { "?username", someUsername } };

            mySql.Setup(_ => _.GetReader(expectedQuery, expectedParams)).Returns(dbReader.Object);

            dbReader.Setup(_ => _.Read()).Returns(true);
            dbReader.Setup(_ => _.IsDBNull(It.IsAny<int>())).Returns(false);

            dbReader.Setup(_ => _.GetString(IdColumn)).Returns(someId);
            dbReader.Setup(_ => _.GetString(UsernameColumn)).Returns(someUsername);
            dbReader.Setup(_ => _.GetString(PasswordColumn)).Returns(somePassord);
            dbReader.Setup(_ => _.GetString(EmailColumn)).Returns(someEmail);
            dbReader.Setup(_ => _.GetString(NameColumn)).Returns(someName);
            dbReader.Setup(_ => _.GetString(LastNameColumn)).Returns(someLastName);
            dbReader.Setup(_ => _.GetString(StartDateColumn)).Returns(someStartDate);
            dbReader.Setup(_ => _.GetString(SectorColumn)).Returns(someSector);

            var employeeRepo = new EmployeeRepository(mySql.Object);

            var getEmployeeResult = employeeRepo.GetEmployeeByUsername(someUsername);
            getEmployeeResult.Should().BeEquivalentTo(expectedEmployee);

            dbReader.Verify(_ => _.Close(), Times.Once);
        }

        [Fact]
        public void ReturnNullIfEmployeeNotFound()
        {
            var mySql = new Mock<ISqlExecutor>();
            var dbReader = new Mock<ISqlReader>();
            var expectedQuery = @$"
                SELECT `ID`, `Username`, `Password`, `Email`, `Name`, `LastName`, `StartDate`, `Sector`
                FROM `employees`
                WHERE `Username` = ?username";

            var someUsername = "aUsername";


            Employee? expectedEmployee = null;

            var expectedParams = new Dictionary<string, object> { { "?username", someUsername } };

            mySql.Setup(_ => _.GetReader(expectedQuery, expectedParams)).Returns(dbReader.Object);

            dbReader.Setup(_ => _.Read()).Returns(false);

            var employeeRepo = new EmployeeRepository(mySql.Object);

            var getEmployeeResult = employeeRepo.GetEmployeeByUsername(someUsername);
            getEmployeeResult.Should().BeEquivalentTo(expectedEmployee);
        }

        [Fact]
        public void UpdateEmployeeWithoutPassword()
        {
            var mySql = new Mock<ISqlExecutor>();

            var someUsername = "aUsername";

            var expectedQuery = @$"
                UPDATE `employees`
                SET  `Username` = ?username, `Email` = ?email, `Name` = ?name, `LastName` = ?lastName, `StartDate` = ?startDate, `Sector` = ?sector
                WHERE `ID` = ?id";

            var someId = "2";

            var someEmail = "aEmail";

            var someName = "aName";

            var someLastName = "aLastName";

            var someStartDate = "2021-02-03";

            var someSector = "aSector";

            var anEmployee = new Employee()
            {
                ID = int.Parse(someId),
                Username = someUsername,
                Password = "",
                Email = someEmail,
                Name = someName,
                LastName = someLastName,
                StartDate = DateTime.Parse(someStartDate),
                Sector = someSector
            };

            var expectedParams = new Dictionary<string, object> {
                {"?id", anEmployee.ID},
                {"?username", anEmployee.Username},
                {"?email",  anEmployee.Email},
                {"?name",  anEmployee.Name},
                {"?lastName",  anEmployee.LastName},
                {"?startDate",  anEmployee.StartDate},
                {"?sector", anEmployee.Sector},
            };

            mySql.Setup(_ => _.ExecuteNonQuery(expectedQuery, expectedParams)).Returns(2);

            var employeeRepo = new EmployeeRepository(mySql.Object);

            anEmployee.Invoking(emp => employeeRepo.UpdateEmployee(emp)).Should().NotThrow();

            mySql.Verify(_ => _.ExecuteNonQuery(expectedQuery, expectedParams));
        }
    }
}