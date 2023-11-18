using DomainEnums;
using Entities;
using Xunit;

namespace UnitTests;

public class Assignment_UnitTests
{
    private readonly Assignment _assignment;
    public Assignment_UnitTests()
    {
        _assignment = new Assignment(DateTime.Now, 1, EStatus.Overdue, "some description");
    }

    [Fact]
    public void GivenUnexistingStatus_ChangeStatus_ShouldThrowArgumentException()
    {
        //arrange
        var inexistingStatus = int.MaxValue;

        //act-assert
        Assert.Throws<ArgumentException>(() => _assignment.ChangeStatus((EStatus)inexistingStatus));
    }

    [Fact]
    public void GivenValidStatus_ChangeStatus_ShouldReturnTrue()
    {
        //arrange
        var validStatus = EStatus.Done;

        //act
        var res = _assignment.ChangeStatus(validStatus);
        //assert
        Assert.True(res);
    }

    [Fact]
    public void GivenDoneStatus_ChangeStatus_ShouldReturnTrueANDSetAssignmentAsCompleted()
    {
        //arrange
        var validStatus = EStatus.Done;

        //act
        var res = _assignment.ChangeStatus(validStatus);

        //assert
        Assert.True(res);
        Assert.True(_assignment.Completed);
    }

    [Fact]
    public void GivenDateEarlierThanToday_ChangeDueDate_ShouldThrowArgumentException()
    {
        // Arrange
        var invalidDate = new DateTime();

        // Act- Assert
        Assert.Throws<ArgumentException>(() => _assignment.ChangeDueDate(invalidDate));


    }

    [Fact]
    public void GivenValidDate_ChangeDueDate_ShouldReturnTrue()
    {
        // Arrange
        var validDate = DateTime.Now;

        // Act
        var res = _assignment.ChangeDueDate(validDate);
        // Assert
        Assert.True(res);
    }
}
