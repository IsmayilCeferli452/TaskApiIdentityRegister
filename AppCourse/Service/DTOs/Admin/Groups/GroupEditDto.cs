namespace Service.DTOs.Admin.Groups
{
    public record GroupEditDto(string name, int capacity, int educationId, int roomId, int teacherId)
    {
    }
}
