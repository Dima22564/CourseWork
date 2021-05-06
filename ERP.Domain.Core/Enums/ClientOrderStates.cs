using System;
using System.Collections.Generic;

namespace ERP.Domain.Core.Enums
{
    public enum ClientOrderStates
    {
        Open,
        ApprovalIsExpected,
        ReadyForShipment,
        ShipmentInProgress,
        PaymentIsExpected,
        Checking,
        Close
    }
}