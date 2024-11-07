public class CustomerRepository
{
	private static readonly Dictionary<int, (string Name, string Email)> customers = new()
	{
		{ 1, ("Alice Smith", "alice@example.com") },
		{ 2, ("Bob Johnson", "bob@example.com") }
	};

	public Task<(string Name, string Email)?> GetCustomerByIdAsync(int id) =>
		Task.FromResult<(string Name, string Email)?>(customers.ContainsKey(id) ? customers[id] : null);
}
