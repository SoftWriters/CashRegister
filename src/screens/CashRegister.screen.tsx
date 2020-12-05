import React, { ReactElement, useState } from 'react';
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
import { calculateChange } from '../utils/cash-register.util';

const CashRegisterScreen: React.FC = (): ReactElement => {
    const [change, setChange] = useState<Map<string, number> | null>(null);
    const [totalDue, setTotalDue] = useState<string>('');
    const [amountPaid, setAmountPaid] = useState<string>('');
    const [submitDisabled, setSubmitDisabled] = useState<boolean>(true);

    const totalDueMet = (totalDue: string, amountPaid: string) => 
        convertToCents(amountPaid) >= convertToCents(totalDue);

    const displayInputErrorMsg = () => {
        if (!totalDue || !amountPaid) {
            return '';
        }

        return totalDueMet(totalDue, amountPaid) ? '' : 'Amount Paid must be equal to/greater than Total Due.';
    };

    const updateSubmitDisabled = (totalDue: string, amountPaid: string): void => {
        const valid = totalDue && amountPaid && totalDueMet(totalDue, amountPaid);
        setSubmitDisabled(!valid);
    };

    const setDisabledStyles = (mainStyle: TextStyle, disabledStyle: ViewStyle) => {
        return submitDisabled ? { ...mainStyle, ...disabledStyle } : mainStyle;
    };

    const getChange = () => {
        Keyboard.dismiss();
        setChange(
            calculateChange(
                convertToCents(totalDue), 
                convertToCents(amountPaid)
            )
        );
    };

    return (
        <View style={styles.viewParent}>
            <ChangeInput 
                placeholder="Enter total due"
                value={totalDue}
                onInputChange={(newTotalDue) => {
                    setTotalDue(newTotalDue);
                    updateSubmitDisabled(newTotalDue, amountPaid);
                }}
            />

            <ChangeInput 
                placeholder="Enter amount paid"
                value={amountPaid}
                onInputChange={(newAmountPaid) => {
                    setAmountPaid(newAmountPaid);
                    updateSubmitDisabled(totalDue, newAmountPaid);
                }}
                onSubmitEditing={() => submitDisabled ? null : getChange()}
            />

            <Text style={styles.inputValidationText}>
                {displayInputErrorMsg()}
            </Text>
            
            <TouchableOpacity
                activeOpacity={0.75}
                style={styles.buttonResetParent}
                onPress={() => {
                    setChange(null);
                    setTotalDue('');
                    setAmountPaid('');
                    setSubmitDisabled(true);
                }} 
            >
                <Text style={styles.buttonReset}>Reset</Text>
            </TouchableOpacity>
            <TouchableOpacity
                disabled={submitDisabled}
                activeOpacity={0.75}
                style={setDisabledStyles(styles.buttonSubmitParent, styles.buttonDisabled)}
                onPress={getChange} 
            >
                <Text 
                    style={setDisabledStyles(styles.buttonSubmit, styles.buttonDisabled)}
                >
                    Get Change
                </Text>
            </TouchableOpacity>
            { 
                change ? 
                    <KeyboardAvoidingView 
                        style={{ flex: Platform.OS == "android" ? 1 : null }} >
                        <ChangeResults 
                            change={change}
                            totalDue={convertToCents(totalDue)}
                            amountPaid={convertToCents(amountPaid)}
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

//     <TextInput
//     style={styles.input}
//     placeholder="Enter total due"
//     keyboardType={setNumericKeyboardType()}
//     value={totalDue.toString()}
//     onChangeText={(newTotalDue) => {
//         setTotalDue(newTotalDue);
//         checkSubmitDisabled(newTotalDue, amountPaid);
//     }}
// />
// <TextInput
//     style={styles.input}
//     placeholder="Enter amount paid"
//     keyboardType={setNumericKeyboardType()}
//     value={amountPaid.toString()}
//     onChangeText={(newAmountPaid) => {
//         setAmountPaid(newAmountPaid);
//         checkSubmitDisabled(totalDue, newAmountPaid);
//     }}
// />
