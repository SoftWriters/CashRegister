import React, { ReactElement, useReducer } from 'react';
import {
    Platform,
    Keyboard,
    KeyboardAvoidingView,
    View,
    Text,
    TouchableOpacity,
    StyleSheet,
    ViewStyle,
    TextStyle,
} from 'react-native';
import ChangeInput from './ChangeInput.component';
import ChangeResults from './ChangeResults.component';
import { convertToCents } from '../utils/helpers.util';
import { USCurrencyDenom } from '../enums/us-currency-denom.enum';
import { calculateChange, US_DENOMS_BY_CENTS } from '../utils/cash-register.util';

enum Action {
    SetTotalDue = 'set_total_due',
    SetAmountPaid = 'set_amount_paid',
    CalculateChange = 'calculate_change',
    Reset = 'reset'
}

type Actions =
    { type: Action.SetTotalDue, payload: string } |
    { type: Action.SetAmountPaid, payload: string } |
    { type: Action.CalculateChange, payload: Map<string, number> } |
    { type: Action.Reset };

type State = {
    totalDue: string,
    amountPaid: string,
    changeDue: string,
    paidInFull: boolean,
    change: Map<string, number>
};

const totalDueMet = (totalDue: string, amountPaid: string) => 
    convertToCents(amountPaid) >= convertToCents(totalDue);

const reducer = (state: State, action: Actions): State => {
    switch (action.type) {
        case Action.SetTotalDue:
            const newTotalDue = action.payload;
            return { 
                ...state, 
                totalDue: newTotalDue,
                paidInFull: newTotalDue && state.amountPaid && totalDueMet(newTotalDue, state.amountPaid)
            };
        case Action.SetAmountPaid:
            const newAmountPaid = action.payload;
            return { 
                ...state, 
                amountPaid: newAmountPaid,
                paidInFull: state.totalDue && newAmountPaid && totalDueMet(state.totalDue, newAmountPaid)
            };
        case Action.CalculateChange:
            const centsPerDollar = US_DENOMS_BY_CENTS.find(d => d.name === USCurrencyDenom.Dollar).value;
            const newChangeDue = convertToCents(state.amountPaid) - convertToCents(state.totalDue);

            Keyboard.dismiss();
            
            return { ...state, changeDue: `$${(newChangeDue / centsPerDollar).toFixed(2)}`, change: action.payload };
        case Action.Reset:
            return { amountPaid: '', totalDue: '', changeDue: '', paidInFull: false, change: null };
        default:
            return state;
    }
};

const CashRegisterScreen: React.FC = (): ReactElement => {
    const [state, dispatch] = useReducer(reducer, {
        amountPaid: '',
        totalDue: '',
        changeDue: '',
        paidInFull: false,
        change: null
    });
    const { amountPaid, totalDue, changeDue, paidInFull, change } = state;

    const displayInputErrorMsg = () => {
        if (!totalDue || !amountPaid) {
            return '';
        }

        return totalDueMet(totalDue, amountPaid) ? '' : 'Amount Paid must be equal to/greater than Total Due.';
    };

    const setDisabledStyles = (mainStyle: TextStyle, disabledStyle: ViewStyle) => {
        return paidInFull ? mainStyle : { ...mainStyle, ...disabledStyle };
    };

    return (
        <View style={styles.viewParent}>
            <ChangeInput 
                placeholder="Enter total due"
                value={totalDue}
                onInputChange={(newTotalDue) => dispatch({ type: Action.SetTotalDue, payload: newTotalDue })}
            />

            <ChangeInput 
                placeholder="Enter amount paid"
                value={amountPaid}
                onInputChange={(newAmountPaid) => dispatch({ type: Action.SetAmountPaid, payload: newAmountPaid })}
                onSubmitEditing={() => paidInFull ? dispatch({
                    type: Action.CalculateChange, 
                    payload: calculateChange(
                        convertToCents(state.totalDue), 
                        convertToCents(state.amountPaid)
                    )}) : null
                }
            />

            <Text style={styles.inputValidationText}>
                {displayInputErrorMsg()}
            </Text>
            
            <TouchableOpacity
                activeOpacity={0.75}
                style={styles.buttonResetParent}
                onPress={() => dispatch({ type: Action.Reset })} 
            >
                <Text style={styles.buttonReset}>Reset</Text>
            </TouchableOpacity>
            
            <TouchableOpacity
                disabled={!paidInFull}
                activeOpacity={0.75}
                style={setDisabledStyles(styles.buttonSubmitParent, styles.buttonDisabled)}
                onPress={() => dispatch({
                    type: Action.CalculateChange, 
                    payload: calculateChange(
                        convertToCents(state.totalDue), 
                        convertToCents(state.amountPaid)
                    )}
                )} 
            >
                <Text style={setDisabledStyles(styles.buttonSubmit, styles.buttonDisabled)}>
                    Get Change
                </Text>
            </TouchableOpacity>

            { 
                change ? 
                    <KeyboardAvoidingView 
                        style={{ flex: Platform.OS == "android" ? 1 : null }} >
                        <ChangeResults 
                            changeReceived={change}
                            changeDue={changeDue}
                        />
                    </KeyboardAvoidingView> : 
                    null 
            }
        </View>
    );
};

const styles = StyleSheet.create({
    viewParent: {
        marginTop: 25,
        justifyContent: 'space-around',
        alignItems: 'stretch'
    },
    input: {
        backgroundColor: '#DEDEDE',
        fontSize: 18,
        height: 50,
        marginTop: 10,
        marginHorizontal: 15,
        padding: 10,
        borderRadius: 10
    },
    inputValidationText: {
        margin: 15,
        fontWeight: 'bold',
        color: 'red'
    },
    buttonSubmitParent: {
        fontWeight: 'bold',
        alignItems: 'center',
        backgroundColor: '#85BB65',
        margin: 10,
        padding: 15,
        borderRadius: 10
    },
    buttonSubmit: {
        fontSize: 18,
        fontWeight: 'bold',
        color: '#000000'
    },
    buttonResetParent: {
        fontWeight: 'bold',
        alignItems: 'center',
        backgroundColor: '#C6C6C6',
        marginLeft: 10,
        marginRight: 10,
        padding: 15,
        borderRadius: 10
    },
    buttonReset: {
        fontSize: 18,
        fontWeight: 'bold',
        color: '#000000'
    },
    buttonDisabled: {
        backgroundColor: '#DEDEDE',
        color: '#AEAEB2'
    }
});

export default CashRegisterScreen;
