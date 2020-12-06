import React, { ReactElement } from 'react';
import { Platform, View, Text, StyleSheet } from 'react-native';
import { TextInputMask } from 'react-native-masked-text';

interface Props {
    label: string,
    placeholder: string,
    value: string,
    onInputChange: (input: string) => void,
    onSubmitEditing?: () => void
}

const ChangeInput: React.FC<Props> = ({ label, placeholder, value, onInputChange, onSubmitEditing }): ReactElement => {
    return (
        <View>
            <Text style={styles.label}>{label}</Text>
            <TextInputMask
                style={styles.input}
                placeholder={placeholder}
                keyboardType={Platform.OS === 'ios' ? 'numeric' : 'number-pad'}
                type={'money'}
                options={{
                    precision: 2,
                    separator: '.',
                    delimiter: ',',
                    unit: '$'
                }}
                value={value}
                onChangeText={onInputChange}
                onSubmitEditing={onSubmitEditing}
            />
        </View>
    );
};

const styles = StyleSheet.create({
    label: {
        margin: 10,
        marginLeft: 18,
        fontWeight: 'bold'
    },
    input: {
        backgroundColor: '#DEDEDE',
        fontSize: 18,
        height: 50,
        marginHorizontal: 15,
        padding: 10,
        borderRadius: 10
    }
});

export default ChangeInput;
