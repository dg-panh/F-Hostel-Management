import React, { Dispatch, FC, SetStateAction } from 'react'
import * as Styled from './styles'
import InputField from '../../../../components/Input/InputField'
import { fields } from './fields'

interface IRoomFormProps {
    values: Record<string, any>
    handleInputChange: Dispatch<SetStateAction<any>>
}

const RoomForm: FC<IRoomFormProps> = ({ values, handleInputChange }) => {
    return (
        <Styled.Wrapper>
            <Styled.Side>
                {values.quantity && (
                    <InputField
                        label="Quantity"
                        name="quantity"
                        value={values.quantity}
                        type="number"
                        required={true}
                        inputProps={{ min: 1 }}
                        onChange={handleInputChange}
                    />
                )}
                {fields.slice(1, 5).map((field) => (
                    <InputField
                        key={field.name}
                        label={field.label}
                        name={field.name}
                        value={values[field.name]}
                        type={field.type}
                        required={field.required}
                        disabled={field.disabled}
                        endAdornment={field.endAdornment}
                        inputProps={field.inputProps}
                        onChange={handleInputChange}
                    />
                ))}
            </Styled.Side>
            <Styled.Side>
                {fields.slice(5, 10).map((field) => (
                    <InputField
                        key={field.name}
                        label={field.label}
                        name={field.name}
                        value={values[field.name]}
                        type={field.type}
                        required={field.required}
                        disabled={field.disabled}
                        endAdornment={field.endAdornment}
                        inputProps={field.inputProps}
                        onChange={handleInputChange}
                    />
                ))}
            </Styled.Side>
        </Styled.Wrapper>
    )
}

export default RoomForm
