﻿using System.Collections.Generic;
using Shuttle.Core.Contract;
using Shuttle.Core.Pipelines;
using Shuttle.Core.PipelineTransaction;

namespace Shuttle.Esb
{
    public class ControlInboxMessagePipeline : ReceiveMessagePipeline
    {
        public ControlInboxMessagePipeline(IServiceBusConfiguration configuration, IEnumerable<IPipelineObserver> observers, ITransactionScopeObserver transactionScopeObserver)
            : base(observers, transactionScopeObserver)
        {
            Guard.AgainstNull(configuration, nameof(configuration));

            State.SetWorkQueue(configuration.ControlInbox.WorkQueue);
            State.SetErrorQueue(configuration.ControlInbox.ErrorQueue);
            State.SetDurationToIgnoreOnFailure(configuration.ControlInbox.DurationToIgnoreOnFailure);
            State.SetMaximumFailureCount(configuration.ControlInbox.MaximumFailureCount);
        }
    }
}