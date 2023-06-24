﻿using PersonAddressLibrary.Framework.Models.AddressTypes;

namespace PersonAddressLibrary.Framework.Models.Addresses
{
    public abstract class PersonAddressModel : IPersonAddressModel
    {
        private AddressType.AddressTypes _addressTypeSelected;
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public IAddressState State { get; set; }
        public string ZipCode { get; set; }

        AddressType.AddressTypes IPersonAddressModel.AddressTypeSelected
        {
            get => _addressTypeSelected;
            set => _addressTypeSelected = value;
        }

        public AddressType AddressType { get; set; }

        public string FullAddress => GetFullAddressString();

        public virtual string GetFullAddressString()
        {
            if (string.IsNullOrWhiteSpace(Address2))
            {
                return $"({AddressType.Name}) {Address1}, {City}, {State.Abbreviation} {ZipCode}";
            }
            return $"({ AddressType.Name }) {Address1}, {Address2}, {City}, {State.Abbreviation} {ZipCode}";
        }

        public virtual void SelectAddressType(AddressType.AddressTypes addressType)
        {
            _addressTypeSelected = addressType;

            switch (addressType)
            {
                case AddressType.AddressTypes.Home:
                    AddressType = new HomeAddressType();
                    break;
                case AddressType.AddressTypes.Shipping:
                    AddressType = new ShippingAddressType();
                    break;
                case AddressType.AddressTypes.Work:
                    AddressType = new WorkAddressType();
                    break;
                default:
                    AddressType = new HomeAddressType();
                    break;
            }
        }

        public virtual AddressType.AddressTypes GetAddressTypeSelected(AddressType.AddressTypes addressType)
        {
            SelectAddressType(addressType);
            return this._addressTypeSelected;
        }
    }
}
