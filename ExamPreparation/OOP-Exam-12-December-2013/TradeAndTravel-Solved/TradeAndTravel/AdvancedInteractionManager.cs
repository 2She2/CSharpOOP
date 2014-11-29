using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class AdvancedInteractionManager : InteractionManager
    {
        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;

            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }

            return person;
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }

            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }

            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            // Where must call the base
            switch (commandWords[1])
            {
                case "gather":
                    this.HandleGatherInteraction(actor, commandWords[2]);
                    break;
                case "craft":
                    this.HandleCraftInteraction(actor, commandWords[2], commandWords[3]);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleGatherInteraction(Person actor, string itemName)
        {
            if (actor.Location.LocationType == LocationType.Forest)
            {
                if (actor.ListInventory().Exists(x => x.ItemType == ItemType.Weapon))
                {
                    this.AddToPerson(actor, (new Wood(itemName)));
                }
            }
            else if (actor.Location.LocationType == LocationType.Mine)
            {
                if (actor.ListInventory().Exists(x => x.ItemType == ItemType.Armor))
                {
                    this.AddToPerson(actor, (new Iron(itemName)));
                }
            }
        }

        private void HandleCraftInteraction(Person actor, string itemType, string itemName)
        {
            if (itemType == "armor")
            {
                if (actor.ListInventory().Exists(x => x.ItemType == ItemType.Iron))
                {
                    this.AddToPerson(actor, (new Armor(itemName)));
                }
            }
            else if (itemType == "weapon")
            {
                if (actor.ListInventory().Exists(x => x.ItemType == ItemType.Iron) &&
                    actor.ListInventory().Exists(x => x.ItemType == ItemType.Wood))
                {
                    this.AddToPerson(actor, (new Weapon(itemName)));
                }
            }
        }
    }
}
