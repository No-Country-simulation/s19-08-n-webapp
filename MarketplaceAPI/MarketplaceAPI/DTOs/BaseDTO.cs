﻿namespace MarketplaceAPI.DTOs
{
    public class BaseDTO
    {
        public object CreateResponse(bool success = true)
        {
            return new
            {
                Success = success,
                Message = "Ok!"
            };
        }
        public object CreateResponse(string publicKey, bool success = true)
        {
            return new
            {
                Success = success,
                Message = "Ok!",
                PublicKey = publicKey,
            };
        }
    }
}   