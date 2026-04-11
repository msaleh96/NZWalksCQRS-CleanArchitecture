namespace Application.Common.Exceptions;

public class NotFoundException(string entity, Guid id) : Exception($"{entity} with ID {id} not found");