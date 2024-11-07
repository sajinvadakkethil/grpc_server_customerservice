using Grpc.Core;
using GrpcExample.Protos;

public class CustomerServiceImpl : CustomerService.CustomerServiceBase
{
	private readonly CustomerRepository _repository;

	public CustomerServiceImpl(CustomerRepository repository)
	{
		_repository = repository;
	}

	public override async Task<CustomerResponse> GetCustomerInfo(
		CustomerRequest request, ServerCallContext context)
	{
		var customer = await _repository.GetCustomerByIdAsync(request.CustomerId);
		if (customer == null) throw new RpcException(new Status(StatusCode.NotFound, "Customer not found"));

		return new CustomerResponse
		{
			CustomerId = request.CustomerId,
			Name = customer.Value.Name,
			Email = customer.Value.Email
		};
	}
}
