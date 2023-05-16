using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FargoEncodingPrinting.Library.Enums
{
    enum CardStatus
    {
        NoCardInPrinter = 0,
        CardFeeding,
        CardDockedOk,
        CardConnecting,
        CardConnected,
        CardDisconnecting,
        CardDisconnected,
        CardEjecting,
        CardHasError,
        CardFeedError,
        CardPrinting,
    };
}
