namespace Service.DTOs.Admin.Groups
{
    public record GroupCreateDto(string name, int capacity, int educationId, int roomId, int teacherId)
    {
    }
}
