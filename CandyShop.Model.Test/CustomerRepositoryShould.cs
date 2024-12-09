using CandyShop.Model.Entities;
using CandyShop.Model.Repositories;

namespace CandyShop.Model.Test;

public class CustomerRepositoryShould
{
    [Fact]
    public void ReturnCustomerList()
    {
        var repository = new Mock<ISqlExecutor>();
        var repositoryReader = new Mock<ISqlReader>();

        var query = @"
                SELECT `ID`, `Username`, `Password`, `Email`, `Name`, `LastName`, `DateOfBirth`, `Address`, `IsTest`
                FROM `customers`";

        var testId = "28";
        var testUsername = "testUsername";
        var testPassword = "testPassword";
        var testEmail = "testEmail";
        var testName = "testName";
        var testLastName = "testLastName";
        var testDateOfBirth = "2002-05-28";
        var testAddress = "testAddress";
        var testIsTest = "1";

        var customer = new Customer()
        {
            ID = int.Parse(testId),
            Username = testUsername,
            Password = testPassword,
            Email = testEmail,
            Name = testName,
            LastName = testLastName,
            DateOfBirth = DateTime.Parse(testDateOfBirth),
            Address = testAddress,
            IsTest = true
        };

        repository.Setup(_ => _.GetReader(query, new Dictionary<string, object>())).Returns(repositoryReader.Object);

        repositoryReader.Setup(_ => _.Read()).Returns(true);
        repositoryReader.Setup(_ => _.IsDBNull(It.IsAny<int>())).Returns(false);

        repositoryReader.Setup(_ => _.GetString(0)).Returns(testId);
        repositoryReader.Setup(_ => _.GetString(1)).Returns(testUsername);
        repositoryReader.Setup(_ => _.GetString(2)).Returns(testPassword);
        repositoryReader.Setup(_ => _.GetString(3)).Returns(testEmail);
        repositoryReader.Setup(_ => _.GetString(4)).Returns(testName);
        repositoryReader.Setup(_ => _.GetString(5)).Returns(testLastName);
        repositoryReader.Setup(_ => _.GetString(6)).Returns(testDateOfBirth);
        repositoryReader.Setup(_ => _.GetString(7)).Returns(testAddress);
        repositoryReader.Setup(_ => _.GetString(8)).Returns(testIsTest);

        var customerRepository = new CustomerRepository(repository.Object);

        var list = customerRepository.GetCustomerList();
        foreach (var c in list)
            c.Should().BeEquivalentTo(customer);

        repositoryReader.Verify(_ => _.Close(), Times.Once);
    }

    [Fact]
    public void ReturnEmptyCustomerList()
    {
        var repository = new Mock<ISqlExecutor>();
        var repositoryReader = new Mock<ISqlReader>();

        var query = @"
                SELECT `ID`, `Username`, `Password`, `Email`, `Name`, `LastName`, `DateOfBirth`, `Address`, `IsTest`
                FROM `customers`";

        repository.Setup(_ => _.GetReader(query, new Dictionary<string, object>())).Returns(repositoryReader.Object);

        repositoryReader.Setup(_ => _.Read()).Returns(false);
        repositoryReader.Setup(_ => _.IsDBNull(It.IsAny<int>())).Returns(false);

        var customerRepository = new CustomerRepository(repository.Object);

        var list = customerRepository.GetCustomerList();
        list.Should().BeEmpty();

        repositoryReader.Verify(_ => _.Close(), Times.Once);
    }

    [Fact]
    public void UpdateCustomerWithoutPassword()
    {
        var repository = new Mock<ISqlExecutor>();

        var query = @$"
                UPDATE `customers`
                SET  `Username` = ?username, `Email` = ?email, `Name` = ?name, `LastName` = ?lastName, `DateOfBirth` = ?dateOfBirth, `Address` = ?address, `IsTest` = ?isTest
                WHERE `ID` = ?id";

        var customer = new Customer()
        {
            ID = 28,
            Username = "testUsername",
            Email = "testEmail",
            Name = "testName",
            LastName = "testLastName",
            DateOfBirth = DateTime.Parse("2002-05-28"),
            Address = "testAddress",
            IsTest = true
        };

        var parameters = new Dictionary<string, object> {
            {"?id", customer.ID},
            {"?username", customer.Username},
            {"?email",  customer.Email},
            {"?name",  customer.Name},
            {"?lastName",  customer.LastName},
            {"?dateOfBirth",  customer.DateOfBirth},
            {"?address", customer.Address},
            { "?isTest", 1}
        };

        repository.Setup(_ => _.ExecuteNonQuery(query, parameters)).Returns(1);
        var customerRepository = new CustomerRepository(repository.Object);
        customer.Invoking(c => customerRepository.UpdateCustomer(c)).Should().NotThrow();
        repository.Verify(_ => _.ExecuteNonQuery(query, parameters));
    }

    [Fact]
    public void UpdateCustomerWithPassword()
    {
        var repository = new Mock<ISqlExecutor>();

        var query = @$"
                UPDATE `customers`
                SET `Password` = ?password, `Username` = ?username, `Email` = ?email, `Name` = ?name, `LastName` = ?lastName, `DateOfBirth` = ?dateOfBirth, `Address` = ?address, `IsTest` = ?isTest
                WHERE `ID` = ?id";

        var customer = new Customer()
        {
            ID = 28,
            Username = "testUsername",
            Password = "testPassword",
            Email = "testEmail",
            Name = "testName",
            LastName = "testLastName",
            DateOfBirth = DateTime.Parse("2002-05-28"),
            Address = "testAddress",
            IsTest = true
        };

        var parameters = new Dictionary<string, object> {
            {"?id", customer.ID},
            {"?username", customer.Username},
            {"?email",  customer.Email},
            {"?name",  customer.Name},
            {"?lastName",  customer.LastName},
            {"?dateOfBirth",  customer.DateOfBirth},
            {"?address", customer.Address},
            {"?isTest", 1},
            {"?password", customer.Password}
        };

        repository.Setup(_ => _.ExecuteNonQuery(query, parameters)).Returns(1);
        var customerRepository = new CustomerRepository(repository.Object);
        customer.Invoking(c => customerRepository.UpdateCustomer(c)).Should().NotThrow();
        repository.Verify(_ => _.ExecuteNonQuery(query, parameters));
    }

    [Fact]
    public void UpdateCustomerThrowDatabaseException()
    {
        var repository = new Mock<ISqlExecutor>();

        var query = @$"
                UPDATE `employees`
                SET `Password` = ?password, `Username` = ?username, `Email` = ?email, `Name` = ?name, `LastName` = ?lastName, `StartDate` = ?startDate, `Sector` = ?sector
                WHERE `ID` = ?id";

        var customer = new Customer()
        {
            ID = 28,
            Username = "testUsername",
            Password = "testPassword",
            Email = "testEmail",
            Name = "testName",
            LastName = "testLastName",
            DateOfBirth = DateTime.Parse("2002-05-28"),
            Address = "testAddress",
            IsTest = true
        };

        var parameters = new Dictionary<string, object> {
            {"?id", customer.ID},
            {"?username", customer.Username},
            {"?password", customer.Password},
            {"?email",  customer.Email},
            {"?name",  customer.Name},
            {"?lastName",  customer.LastName},
            {"?dateOfBirth",  customer.DateOfBirth},
            {"?address", customer.Address },
            { "?isTest", 1 }
        };

        repository.Setup(_ => _.ExecuteNonQuery(query, parameters)).Returns(0);
        var customerRepository = new CustomerRepository(repository.Object);
        customer.Invoking(c => customerRepository.UpdateCustomer(c)).Should().Throw<DatabaseException>();
    }
}