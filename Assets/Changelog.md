# Terminal Twilight RPG Changelog

## Shop
* The Shop Menu will only open if the ShopCanvas is active.

__The following methods are in the ShopManager.__
* To open the Shop Menu, call the _OpenShopMenu( )_ method.
* To close the Shop Menu, call the _CloseShopMenu( )_ method.
* To open the Buy Quantity Dialog, call the _OpenPopUp( )_ method.
* To close the Buy Quantity Dialog, call the _ClosePopUp( )_ method.

The ShopCanvas does not have to be deactivated since the Animation system manages the visibility of the Shop Menu.
However, if you choose to deactivate the ShopCanvas (maybe to save memory), you must remember to reactivate the ShopCanvas for the
_OpenShopMenu( )_ and _CloseShopMenu( )_ methods to work correctly.
