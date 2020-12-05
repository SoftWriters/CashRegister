import React, { ReactElement, useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, Image, StyleSheet } from 'react-native';
import { calculateChange } from '../utils/cash-register.util';

const CashRegisterScreen: React.FC = (): ReactElement => {
    const [change, setChange] = useState<Map<string, number> | null>(null);
    const [totalDue, setTotalDue] = useState<string>('');
    const [amountPaid, setAmountPaid] = useState<string>('');

    return (
        <View style={styles.backgroundStyle}>
            <TextInput
                style={styles.inputStyle}
                placeholder="Enter total due"
                value={totalDue.toString()}
                onChangeText={(newTotalDue) => setTotalDue(newTotalDue)}
            />
            <TextInput
                style={styles.inputStyle}
                placeholder="Enter amount paid"
                value={amountPaid.toString()}
                onChangeText={(newAmountPaid) => setAmountPaid(newAmountPaid)}
            />

            <TouchableOpacity
                activeOpacity={0.75}
                style={styles.buttonParentStyle}
                onPress={() => setChange(calculateChange(parseInt(totalDue), parseInt(amountPaid)))} >
                <Text style={styles.buttonStyle}>Get Change</Text>
            </TouchableOpacity>

            {
                change ?
                    [...change].map(([ denom, qty ]) => (
                        <Text key={denom}>{denom}: {qty}</Text>
                    )) :
                    null
            }
        </View>
    );
};

const styles = StyleSheet.create({
    backgroundStyle: {
        marginTop: 25,
        justifyContent: 'space-around',
        alignItems: 'stretch'
    },
    inputStyle: {
        backgroundColor: '#DEDEDE',
        fontSize: 18,
        height: 50,
        marginTop: 10,
        marginHorizontal: 15,
        padding: 10,
        borderRadius: 10
    },
    buttonParentStyle: {
        fontWeight: 'bold',
        alignItems: 'center',
        backgroundColor: '#85bb65',
        marginTop: 16,
        marginLeft: 10,
        marginRight: 10,
        marginBottom: 10,
        padding: 15,
        borderRadius: 10
    },
    buttonDisabledStyle: {
        backgroundColor: '#DEDEDE',
        color: '#FFFFFF'
    },
    buttonStyle: {
        fontSize: 18,
        fontWeight: 'bold'
    }
});

export default CashRegisterScreen;
