import React, { ReactElement } from 'react';
import pluralize from 'pluralize';
import {
    View,
    Text,
    StyleSheet,
} from 'react-native';

interface Props {
    changeDue: string,
    changeReceived: Map<string, number>
}

const ChangeResults: React.FC<Props> = ({ changeDue, changeReceived }): ReactElement => {
    return (
        <View style={styles.viewParent}>
            <Text style={styles.changeDueText}>
                Change Due: {changeDue}
            </Text>
            <View style={styles.changeDenom}>
                {[...changeReceived]
                    .filter(([ denom, qty ]) => qty > 0)
                    .map(([ denom, qty ]) => (
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
