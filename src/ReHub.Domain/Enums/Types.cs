﻿using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ReHub.Domain.Enums
{
    public enum GenderType
    {
        Male,
        Female,
        Other,
        None
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserType
    {
        [EnumMember(Value = "admin")]
        Admin,
        [EnumMember(Value = "doctor")]
        Doctor,
        [EnumMember(Value = "client")]
        Client,
        [EnumMember(Value = "none")]
        None
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserSubType
    {
        [EnumMember(Value = "anamnesis")]
        Anamnesis,
        [EnumMember(Value = "physio")]
        Physio
    }
    public enum AppointmentStatusType
    {
        Pending,
        Active,
        Finished,
        Missed
    }
    public enum ResultMessageType
    {
        Success,
        Error
    }
    public enum AcceptableCurrencyType
    {
        Euro
    }
    public enum PaymentProcessorType
    {
        Stripe,
        Paypal
    }
    public enum PainRateType
    {
        Before,
        After
    }
    public enum PathologyType
    {
        Pathology_1, // Cervicale
        Pathology_2, // Spalle e dorso (Colonna alta)
        Pathology_3, // Colonna lombare (Schiena bassa)
        Pathology_4, // Addominali e bacino
        Pathology_5, // Braccia
        Pathology_6 // Gambe
    }
    public enum GroupPainRateDataType
    {
        Weekly,
        Monthly,
        Annually,
    }
    public enum CouponType
    {
        One_time,
        Unlimited
    }
    public enum CouponDiscountType
    {
        Percentage,
        Fixed_amount
    }
}