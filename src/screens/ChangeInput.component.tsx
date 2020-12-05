import React, { ReactElement } from 'react';
import { Platform, StyleSheet} from 'react-native';
import { TextInputMask } from 'react-native-masked-text';

interface Props {
    placeholder: string,
    value: string,
    onInputChange: (input: string) => void,
    onSubmitEditing?: () => void
}

const ChangeInput: React.FC<Props> = ({ placeholder, value, onInputChange, onSubmitEditing }): ReactElement => {
    return (
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
    );
};

const styles = StyleSheet.create({
    input: {
        backgroundColor: '#DEDEDE',
        fontSize: 18,
        height: 50,
        marginTop: 10,
        marginHorizontal: 15,
        padding: 10,
        borderRadius: 10
    }
});

export default ChangeInput;
