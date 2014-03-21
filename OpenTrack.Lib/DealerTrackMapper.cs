using System;
using System.Linq;
using OpenTrack.Requests;
using OpenTrack.Responses;

namespace OpenTrack
{
    public static class DealerTrackMapper
    {
        public static Vehicle MapVehicle(VehicleLookupResponseVehicle response)
        {
            return new Vehicle
            {
                BodyStyle = response.BodyStyle,
                BusinessOfficeFranchiseCode = response.BusinessOfficeFranchiseCode,
                CO2EmissionCode = response.CO2EmissionCode,
                CertifiedUsedCar = response.CertifiedUsedCar,
                Color = response.Color,
                CompanyNumber = response.CompanyNumber,
                CustomerKey = response.CustomerKey,
                Cylinders = response.Cylinders,
                DateDelivered = response.DateDelivered,
                DateInInventory = response.DateInInventory,
                DateInService = response.DateInService,
                DateOrdered = response.DateOrdered,
                DealerCode = response.DealerCode,
                DemoName = response.DemoName,
                DocumentNumber = response.DocumentNumber,
                DriverSide = response.DriversSide,
                FourWheelDrive = response.FourWheelDrive,
                FreeFlooringPeriod = Convert.ToInt32(response.FreeFlooringPeriod),
                FuelType = response.FuelType,
                FundingExpirationDate = response.FundingExpirationDate,
                GLApplied = response.GLApplied,
                GrossWeight = Convert.ToDecimal(response.GrossWeight),
                InspectionDate = response.InspectionDate,
                InspectionMonth = Convert.ToInt32(response.InspectionMonth),
                InventoryAccount = response.InventoryAccount,
                KeyToCAPExplosionData = response.KeyToCAPExplosionData,
                LastServiceDate = response.LastServiceDate,
                LicenseNumber = response.LicenseNumber,
                ListPrice = Convert.ToDecimal(response.ListPrice),
                Location = response.Location,
                MPG = response.MPG,
                Make = response.Make,
                ManufactureCode = response.ManufacturerCode,
                Model = response.Model,
                ModelCode = response.ModelCode,
                ModelYear = response.ModelYear,
                NextServiceDate = response.NextServiceDate,
                Odometer = Convert.ToInt32(response.Odometer),
                OdometerActual = response.OdometerActual,
                OptionPackage = response.OptionPackage,
                OptionalFields = response.OptionalFields == null ? null : response.OptionalFields.Select(MapOptionalField).ToList(),
                Options = response.Options == null ? null : response.Options.Select(MapOptions).ToList(),
                OrderedStatus = response.OrderedStatus,
                PublishVehicleInfoToWeb = response.PublishVehicleInfoToWeb,
                RegistrationDate = response.RegistrationDate,
                Sale = response.Sale,
                SaleAccount = response.SaleAccount,
                ServiceFranchiseCode = response.ServiceFranchiseCode,
                Status = response.Status,
                StockNumber = response.StockNumber,
                Trim = response.Trim,
                Truck = response.Truck,
                TypeNU = response.TypeNU,
                VIN = response.VIN,
                VehicleCode = response.VehicleCode,
                VehicleCost = Convert.ToDecimal(response.VehicleCost),
                WarrentyDeduct = Convert.ToInt32(response.WarrantyDeduct),
                WarrentyMiles = Convert.ToInt32(response.WarrantyMiles),
                WarrentyMonths = Convert.ToInt32(response.WarrantyMonths),
                WorkInProcess = Convert.ToDecimal(response.WorkInProcess)
            };
        }

        public static VehicleOption MapOptions(VehicleLookupResponseVehicleOptionsVehicleOption option)
        {
            return new VehicleOption
            {
                Description = option.Description,
                OptionCode = option.OptionCode
            };
        }

        public static VehicleOptionalField MapOptionalField(VehicleLookupResponseVehicleOptionalFieldsVehicleOptionalField optionalField)
        {
            return new VehicleOptionalField
            {
                AddToCostFlag = optionalField.AddToCostFlag,
                AlphaFieldValue = optionalField.AlphaFieldValue,
                DateFieldValue = optionalField.DateFieldValue,
                Description = optionalField.Description,
                FieldType = optionalField.FieldType,
                NumericFieldValue = Convert.ToDecimal(optionalField.NumericFieldValue),
                OptionNumber = Convert.ToInt32(optionalField.OptionNumber)
            };
        } 
    }
}