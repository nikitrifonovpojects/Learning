using System.Collections.Generic;

namespace TradeAndTravel
{
    public class InteractionManagerExtension : InteractionManager
    {
        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            switch (personTypeString)
            {
                case "merchant":
                    return new Merchant(personNameString, personLocation);
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    return new Weapon(itemNameString, itemLocation);
                case "wood":
                    return new Wood(itemNameString, itemLocation);
                case "iron":
                    return new Iron(itemNameString, itemLocation);
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            switch (locationTypeString)
            {
                case "mine":
                    return new Mine(locationName);
                case "forest":
                    return new Forest(locationName);
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                     HandleGatherInteraction(commandWords, actor);
                    break;
                case "craft":
                    var inventory = actor.ListInventory();

                    if (commandWords[2] == "armor")
                    {
                        if (HasItems(ItemType.Iron, inventory))
                        {
                            AddToPerson(actor, new Armor(commandWords[3]));
                        }
                    }
                    else if (commandWords[2] == "weapon")
                    {
                        if (HasItems(ItemType.Iron, inventory) && HasItems(ItemType.Wood, inventory))
                        {
                            AddToPerson(actor, new Weapon(commandWords[3]));
                        }
                    }

                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    return;
            }
        }

        protected void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            var inventory = actor.ListInventory();

            if (actor.Location.LocationType is LocationType.Forest)
            {

                if (HasItems(ItemType.Weapon, inventory))
                {
                    AddToPerson(actor, new Wood(commandWords[2]));
                }
            }
            else if (actor.Location.LocationType is LocationType.Mine)
            {
                if (HasItems(ItemType.Armor, inventory))
                {
                    AddToPerson(actor, new Iron(commandWords[2]));
                }
            }
        }

        protected bool HasItems(ItemType requiredType, List<Item> inventory)
        {
            bool hasItemType = false;
            foreach (var item in inventory)
            {
                if (item.ItemType == requiredType)
                {
                    hasItemType = true;
                    break;
                }
            }

            return hasItemType;
        }
    }
}
