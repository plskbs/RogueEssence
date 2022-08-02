﻿using System;
using RogueEssence.Data;
using RogueElements;
using RogueEssence.Dev;
using Newtonsoft.Json;

namespace RogueEssence.Dungeon
{
    [Serializable]
    public class InvItem : PassiveActive, ISpawnable
    {
        public override GameEventPriority.EventCause GetEventCause()
        {
            return GameEventPriority.EventCause.Equip;
        }
        public override PassiveData GetData() { return DataManager.Instance.GetItem(ID); }

        public override string GetID() { return ID.ToString(); }

        [JsonConverter(typeof(ItemConverter))]
        [DataType(0, DataManager.DataType.Item, false)]
        public string ID { get; set; }
        public bool Cursed;
        public int HiddenValue;
        public int Price;

        public InvItem() : base()
        { ID = ""; }

        public InvItem(string index)
        {
            ID = index;
        }

        public InvItem(string index, bool cursed)
        {
            ID = index;
            Cursed = cursed;
        }
        public InvItem(string index, bool cursed, int hiddenValue)
        {
            ID = index;
            Cursed = cursed;
            HiddenValue = hiddenValue;
        }
        public InvItem(string index, bool cursed, int hiddenValue, int price)
        {
            ID = index;
            Cursed = cursed;
            HiddenValue = hiddenValue;
            Price = price;
        }
        //TODO: String Assets
        public InvItem(InvItem other)// : base(other)
        {
            //TODO: String Assets
            ID = other.ID;
            Cursed = other.Cursed;
            HiddenValue = other.HiddenValue;
            Price = other.Price;
        }
        public ISpawnable Copy() { return new InvItem(this); }


        public string GetPriceString()
        {
            return MapItem.GetPriceString(Price);
        }

        public override string GetDisplayName()
        {
            ItemData entry = DataManager.Instance.GetItem(ID);

            string prefix = "";
            if (entry.Icon > -1)
                prefix += ((char)(entry.Icon + 0xE0A0)).ToString();
            if (Cursed)
                prefix += "\uE10B";

            string nameStr = entry.Name.ToLocal();
            if (entry.MaxStack > 1)
                nameStr += " (" + HiddenValue + ")";

            return String.Format("{0}[color=#FFCEFF]{1}[color]", prefix, nameStr);
        }

        public override string ToString()
        {
            ItemData entry = DataManager.Instance.GetItem(ID);

            string nameStr = "";
            if (Cursed)
                nameStr += "[X]";

            nameStr += entry.Name.ToLocal();
            if (entry.MaxStack > 1)
                nameStr += " (" + HiddenValue + ")";

            return nameStr;
        }

        public int GetSellValue()
        {
            ItemData entry = DataManager.Instance.GetItem(ID);
            if (entry.MaxStack > 1)
                return entry.Price * HiddenValue;
            else
                return entry.Price;
        }
    }
}
