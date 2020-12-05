import React, { ReactElement } from 'react';
import pluralize from 'pluralize';
import { USCurrencyDenom } from '../enums/us-currency-denom.enum';
import { US_DENOMS_BY_CENTS } from '../utils/cash-register.util';
import {
    View,
    Text,
    StyleSheet,
} from 'react-native';

interface Props {
    totalDue: number,
    amountPaid: number,
    change: Map<string, number>
}

const ChangeResults: React.FC<Props> = ({ change, totalDue, amountPaid }): ReactElement => {
    const centsPerDollar = US_DENOMS_BY_CENTS.find(d => d.name === USCurrencyDenom.Dollar).value;
    return (
        <View style={styles.viewParent}>
            <Text style={styles.changeDueText}>
                Change Due: ${((amountPaid - totalDue) / centsPerDollar).toFixed(2)}
            </Text>
            <View style={styles.changeDenom}>
                {[...change].map(([ denom, qty ]) => (
                    <Text style={styles.changeDenomInfo} key={denom}>{qty} {pluralize(denom, qty)}</Text>
                ))}
            </View>
        </View>
    );
};

const styles = StyleSheet.create({
    viewParent: {
        marginTop: 15,
        padding: 15
    },
    changeDueText: {
        fontSize: 20,
        fontWeight: 'bold'
    },
    changeDenom: {
        marginTop: 28
    },
    changeDenomInfo: {
        fontSize: 18,
        fontWeight: '600'
    }
});

export default ChangeResults;
