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
import { currencyStringToInt } from '../utils/helpers.util';
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
    { type: Action.CalculateChange } |
    { type: Action.Reset };

type State = {
    totalDue: string,
    amountPaid: string,
    paidInFull: boolean,
    changeDue: string,
    changeReceived: Map<string, number>
};

const totalDueMet = (totalDue: string, amountPaid: string) => 
    currencyStringToInt(amountPaid) >= currencyStringToInt(totalDue);

const inputsFilledIn = (totalDue: string, amountPaid: string) =>
    totalDue.length && amountPaid.length;

const reducer = (state: State, action: Actions): State => {
    switch (action.type) {
        case Action.SetTotalDue:
            const newTotalDue = action.payload;
            return { 
                ...state, 
                totalDue: newTotalDue,
                paidInFull: inputsFilledIn(newTotalDue, state.amountPaid) && totalDueMet(newTotalDue, state.amountPaid)
            };
        case Action.SetAmountPaid:
            const newAmountPaid = action.payload;
            return { 
                ...state, 
                amountPaid: newAmountPaid,
                paidInFull: inputsFilledIn(state.totalDue, newAmountPaid) && totalDueMet(state.totalDue, newAmountPaid)
            };
        case Action.CalculateChange:
            const centsPerDollar = US_DENOMS_BY_CENTS.find(d => d.name === USCurrencyDenom.Dollar).value;
            const amountPaidInCents = currencyStringToInt(state.amountPaid);
            const totalDueInCents = currencyStringToInt(state.totalDue);

            const newChangeDue = amountPaidInCents - totalDueInCents;

            Keyboard.dismiss();
            
            return { 
                ...state, 
                changeDue: `$${(newChangeDue / centsPerDollar).toFixed(2)}`, 
                changeReceived: calculateChange(totalDueInCents, amountPaidInCents) 
            };
        case Action.Reset:
            return { amountPaid: '', totalDue: '', changeDue: '', paidInFull: false, changeReceived: null };
        default:
            return state;
    }
};

const CashRegisterScreen: React.FC = (): ReactElement => {
    const [state, dispatch] = useReducer(reducer, {
        totalDue: '',
        amountPaid: '',
        paidInFull: false,
        changeDue: '',
        changeReceived: null
    });
    const { totalDue, amountPaid, paidInFull, changeDue, changeReceived } = state;

    const displayInputErrorMsg = () => {
        return inputsFilledIn(totalDue, amountPaid) && !totalDueMet(totalDue, amountPaid) ? 
            'Amount Paid must be equal to/greater than Total Due.' : 
            '';
    };

    const setDisabledStyles = (mainStyle: TextStyle, disabledStyle: ViewStyle, isDisabled: boolean) => {
        return isDisabled ? { ...mainStyle, ...disabledStyle } : mainStyle;
    };

    return (
        <View style={styles.viewParent}>
            <ChangeInput 
                label="Total Due"
                placeholder="Enter total due"
                value={totalDue}
                onInputChange={(newTotalDue) => dispatch({ type: Action.SetTotalDue, payload: newTotalDue })}
            />

            <ChangeInput
                label="Amount Paid"
                placeholder="Enter amount paid"
                value={amountPaid}
                onInputChange={(newAmountPaid) => dispatch({ type: Action.SetAmountPaid, payload: newAmountPaid })}
                onSubmitEditing={
                    () => paidInFull ? dispatch({ type: Action.CalculateChange }) : null
                }
            />

            <Text style={styles.inputValidationText}>
                {displayInputErrorMsg()}
            </Text>
            
            <TouchableOpacity
                disabled={!inputsFilledIn(amountPaid, totalDue)}
                activeOpacity={0.75}
                style={
                    setDisabledStyles(
                        styles.buttonResetParent, 
                        styles.buttonDisabled, 
                        !inputsFilledIn(amountPaid, totalDue)
                    )}
                onPress={() => dispatch({ type: Action.Reset })} 
            >
                <Text style={
                    setDisabledStyles(
                        styles.buttonReset, 
                        styles.buttonDisabled, 
                        !inputsFilledIn(amountPaid, totalDue)
                    )}>
                    Reset
                </Text>
            </TouchableOpacity>
            
            <TouchableOpacity
                disabled={!paidInFull}
                activeOpacity={0.75}
                style={setDisabledStyles(styles.buttonSubmitParent, styles.buttonDisabled, !paidInFull)}
                onPress={() => dispatch({ type: Action.CalculateChange })} 
            >
                <Text style={setDisabledStyles(styles.buttonSubmit, styles.buttonDisabled, !paidInFull)}>
                    Get Change
                </Text>
            </TouchableOpacity>

            { 
                changeReceived ? 
                    <KeyboardAvoidingView 
                        style={{ flex: Platform.OS === 'android' ? 1 : null }} >
                        <ChangeResults 
                            changeReceived={changeReceived}
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
        marginTop: 5,
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
