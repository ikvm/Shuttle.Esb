using Shuttle.Core.Infrastructure;

namespace Shuttle.ESB.Core
{
	public interface IServiceBusConfiguration
	{
		bool HasInbox { get; }
		bool HasControlInbox { get; }
		bool HasOutbox { get; }
		bool HasIdempotenceService { get; }
		bool HasSubscriptionManager { get; }
		bool IsWorker { get; }
		bool RemoveMessagesNotHandled { get; set; }

		IServiceBusPolicy Policy { get; set; }
		ISerializer Serializer { get; set; }
		IMessageRouteProvider MessageRouteProvider { get; set; }

		IControlInboxQueueConfiguration ControlInbox { get; set; }
		IInboxQueueConfiguration Inbox { get; set; }
		IOutboxQueueConfiguration Outbox { get; set; }

		IMessageHandlerFactory MessageHandlerFactory { get; set; }
		IMessageHandlerInvoker MessageHandlerInvoker { get; set; }
		IMessageHandlingAssessor MessageHandlingAssessor { get; set; }
		IThreadActivityFactory ThreadActivityFactory { get; set; }

		IIdempotenceService IdempotenceService { get; set; }
		ISubscriptionManager SubscriptionManager { get; set; }
		IWorkerConfiguration Worker { get; set; }

		IWorkerAvailabilityManager WorkerAvailabilityManager { get; set; }
		IPipelineFactory PipelineFactory { get; set; }
		IUriResolver UriResolver { get; set; }

		IQueueManager QueueManager { get; set; }
		ModuleCollection Modules { get; }
		ITransactionScopeFactory TransactionScopeFactory { get; set; }
		string EncryptionAlgorithm { get; set; }
		string CompressionAlgorithm { get; set; }
		ITransactionScopeConfiguration TransactionScope { get; set; }
		bool CreateQueues { get; set; }

		IEncryptionAlgorithm FindEncryptionAlgorithm(string name);
		void AddEncryptionAlgorithm(IEncryptionAlgorithm algorithm);

		ICompressionAlgorithm FindCompressionAlgorithm(string name);
		void AddCompressionAlgorithm(ICompressionAlgorithm algorithm);
	}
}