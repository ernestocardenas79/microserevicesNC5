﻿
using Discount.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        public readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;

        public DiscountGrpcService(Discount.Grpc.Protos.DiscountProtoService.DiscountProtoServiceClient discountProtoService)
        {
            _discountProtoService = discountProtoService;
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest { ProductName  = productName };
            return await _discountProtoService.GetDiscountAsync(discountRequest);
        }
    }
}
