using System;

namespace CandyShop.Mobile.Models
{
    public class CommunicationException : Exception
    {
        public CommunicationException(string message) : base(message) { }
    }
}