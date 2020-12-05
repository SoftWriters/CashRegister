import { createAppContainer } from 'react-navigation';
import { createStackNavigator } from 'react-navigation-stack';

import CashRegisterScreen from './src/screens/CashRegister.screen';

const navigator = createStackNavigator({
    CashRegister: CashRegisterScreen
}, 
{
    initialRouteName: 'CashRegister',
    defaultNavigationOptions: {
        title: 'Cash Register'
    }
});

export default createAppContainer(navigator);
