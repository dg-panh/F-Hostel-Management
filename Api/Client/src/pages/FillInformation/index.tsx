import {
    Box,
    Button,
    CardActionArea,
    CardContent,
    Grid,
    Step,
    StepLabel,
    Stepper,
    Typography,
    MenuItem,
    Paper,
    MobileStepper,
    CardMedia,
    TableContainer,
    Table,
    TableBody,
    TableRow,
    TableCell,
} from '@mui/material'
import React, { useEffect, useState } from 'react'
import { useTheme } from '@mui/material/styles'
import FileUploadIcon from '@mui/icons-material/FileUpload'
import InputField from '../../components/Input/InputField'

import * as Styled from './styles'
import { KeyboardArrowLeft, KeyboardArrowRight } from '@mui/icons-material'
import FirebaseService from '../../services/FirebaseService'
import { RestCaller } from '../../utils/RestCaller'
import { useDispatch } from 'react-redux'
import { setToken } from '../../slices/authSlice'
import { useNavigate } from 'react-router-dom'
import { IFirstTimeBody, IFirstTimeResponse, IInformation } from './interfaces'
import { GENDERS, ROLES, STEPS } from './constants'

// Props & type
type InputFieldType = React.ChangeEvent<HTMLInputElement>
interface IFillInformationProps {}
interface IPersonInformationProps {
    state: IInformation
    onChangeState: (state: IInformation) => void
}
interface ISetRoleProps {
    onChangeState: (state: string) => void
}
interface IConfirmInfoProps {
    stateRole: string
    stateInfo: IInformation
}

const SetRole: React.FC<ISetRoleProps> = ({ onChangeState }) => {
    return (
        <Styled.Step>
            <Grid container>
                {ROLES.map((role, index) => (
                    <Grid item key={index} xs={12} md={4}>
                        <Styled.RoleCard elevation={0} variant="outlined">
                            <CardActionArea
                                onClick={() => onChangeState(role.name)}
                            >
                                <CardContent>
                                    <Styled.ImgRole
                                        src={role.icon}
                                        width="100%"
                                    ></Styled.ImgRole>
                                </CardContent>
                            </CardActionArea>
                        </Styled.RoleCard>
                        <Styled.RoleName variant="body2">
                            {role.name}
                        </Styled.RoleName>
                    </Grid>
                ))}
            </Grid>
        </Styled.Step>
    )
}

const PersonalInformation: React.FC<IPersonInformationProps> = ({
    state,
    onChangeState,
}) => {
    const {
        fullName,
        birthDate,
        cardNumber,
        address,
        gender,
        phoneNo,
        imgCard,
    } = state

    const imgCardPre = imgCard?.get(0)
    const imgCardPos = imgCard?.get(1)

    const [previewPre, setPreviewPre] = useState<string>()
    const [previewPos, setPreviewPos] = useState<string>()
    const preview = [previewPre, previewPos]
    const theme = useTheme()
    const [activeStep, setActiveStep] = React.useState(0)
    const maxSteps = 2

    const handleNext = () => {
        setActiveStep((prevActiveStep) => prevActiveStep + 1)
    }

    const handleBack = () => {
        setActiveStep((prevActiveStep) => prevActiveStep - 1)
    }

    useEffect(() => {
        if (imgCardPre) {
            const reader = new FileReader()
            reader.onload = () => {
                setPreviewPre(reader.result as string)
            }
            reader.readAsDataURL(imgCardPre)
        } else {
            setPreviewPre(undefined)
        }
    }, [imgCardPre])

    useEffect(() => {
        if (imgCardPos) {
            const reader = new FileReader()
            reader.onload = () => {
                setPreviewPos(reader.result as string)
            }
            reader.readAsDataURL(imgCardPos)
        } else {
            setPreviewPos(undefined)
        }
    }, [imgCardPos])

    return (
        <Styled.Step>
            <Box
                sx={{
                    display: 'flex',
                    justifyContent: 'center',
                    alignItems: 'center',
                }}
            >
                <Box sx={{ width: '90%' }}>
                    <Grid container spacing={2}>
                        <Grid item xs={12} md={6}>
                            <InputField
                                label="Full name"
                                value={fullName}
                                onChange={(e: InputFieldType) =>
                                    onChangeState({
                                        ...state,
                                        fullName: e.target.value,
                                    })
                                }
                                autoFocus
                            />

                            <InputField
                                label="Address"
                                value={address}
                                onChange={(e: InputFieldType) =>
                                    onChangeState({
                                        ...state,
                                        address: e.target.value,
                                    })
                                }
                            />
                            <InputField
                                label="Birthday"
                                value={birthDate}
                                onChange={(e: InputFieldType) =>
                                    onChangeState({
                                        ...state,
                                        birthDate: e.target.value,
                                    })
                                }
                                InputLabelProps={{
                                    shrink: true,
                                }}
                                type="date"
                            />

                            <InputField
                                label="Gender"
                                value={gender}
                                onChange={(e: InputFieldType) =>
                                    onChangeState({
                                        ...state,
                                        gender: e.target.value,
                                    })
                                }
                                select
                            >
                                {GENDERS.map((option, index) => (
                                    <MenuItem key={index} value={option}>
                                        {option}
                                    </MenuItem>
                                ))}
                            </InputField>

                            <InputField
                                label="Phone number"
                                value={phoneNo}
                                onChange={(e: InputFieldType) =>
                                    onChangeState({
                                        ...state,
                                        phoneNo: e.target.value,
                                    })
                                }
                                type="number"
                            />

                            <InputField
                                label="Citizen ID number"
                                value={cardNumber}
                                onChange={(e: InputFieldType) =>
                                    onChangeState({
                                        ...state,
                                        cardNumber: e.target.value,
                                    })
                                }
                                type="number"
                            />
                        </Grid>

                        {/* CCCD */}
                        <Grid item xs={12} md={6}>
                            <Box
                                sx={{
                                    maxWidth: 400,
                                    flexGrow: 1,
                                    border: '1px solid #dadada',
                                    mt: 2,
                                    textAlign: 'center',
                                }}
                            >
                                <Paper
                                    square
                                    elevation={0}
                                    sx={{
                                        display: 'flex',
                                        alignItems: 'center',
                                        height: 50,
                                        pl: 2,
                                        bgcolor: 'background.default',
                                    }}
                                >
                                    <Typography>Citizen ID photo</Typography>
                                </Paper>

                                {!preview[activeStep] ? (
                                    <CardActionArea
                                        sx={{
                                            height: 255,
                                            maxWidth: 400,
                                            width: '100%',
                                            p: 2,
                                            borderTop: '1px solid #dadada',
                                        }}
                                    >
                                        <label>
                                            <input
                                                type="file"
                                                id="avatar"
                                                accept="image/png, image/jpeg"
                                                style={{ display: 'none' }}
                                                onChange={(e) => {
                                                    const files = e.target.files
                                                    if (!files) return

                                                    const { imgCard } = state
                                                    imgCard?.set(
                                                        activeStep,
                                                        files[0]
                                                    )
                                                    onChangeState({
                                                        ...state,
                                                        imgCard: new Map(
                                                            imgCard
                                                        ),
                                                    })
                                                }}
                                            ></input>

                                            <FileUploadIcon
                                                htmlColor="#a7a7a7"
                                                sx={{
                                                    width: '20%',
                                                    height: 'auto',
                                                }}
                                            />
                                        </label>

                                        <Typography
                                            variant="body2"
                                            sx={{
                                                color: 'grey.600',
                                            }}
                                        >
                                            Upload file
                                        </Typography>
                                    </CardActionArea>
                                ) : (
                                    <CardActionArea>
                                        <CardMedia
                                            component="img"
                                            height="194"
                                            image={preview[activeStep]}
                                            alt="Paella dish"
                                        />
                                        <label>
                                            <input
                                                type="file"
                                                id="avatar"
                                                accept="image/png, image/jpeg"
                                                style={{ display: 'none' }}
                                                onChange={(e) => {
                                                    const files = e.target.files
                                                    if (!files) return

                                                    const { imgCard } = state
                                                    imgCard?.set(
                                                        activeStep,
                                                        files[0]
                                                    )
                                                    onChangeState({
                                                        ...state,
                                                        imgCard: new Map(
                                                            imgCard
                                                        ),
                                                    })
                                                }}
                                            ></input>
                                            <Typography
                                                variant="body2"
                                                sx={{
                                                    color: 'grey.600',
                                                    p: 1,
                                                    cursor: 'pointer',
                                                }}
                                            >
                                                Change file
                                            </Typography>
                                        </label>
                                    </CardActionArea>
                                )}

                                <MobileStepper
                                    variant="text"
                                    steps={2}
                                    position="static"
                                    activeStep={activeStep}
                                    nextButton={
                                        <Button
                                            size="small"
                                            onClick={handleNext}
                                            disabled={
                                                activeStep === maxSteps - 1
                                            }
                                        >
                                            Next
                                            {theme.direction === 'rtl' ? (
                                                <KeyboardArrowLeft />
                                            ) : (
                                                <KeyboardArrowRight />
                                            )}
                                        </Button>
                                    }
                                    backButton={
                                        <Button
                                            size="small"
                                            onClick={handleBack}
                                            disabled={activeStep === 0}
                                        >
                                            {theme.direction === 'rtl' ? (
                                                <KeyboardArrowRight />
                                            ) : (
                                                <KeyboardArrowLeft />
                                            )}
                                            Back
                                        </Button>
                                    }
                                />
                            </Box>
                        </Grid>
                    </Grid>
                </Box>
            </Box>
        </Styled.Step>
    )
}

const ConfirmInfo: React.FC<IConfirmInfoProps> = ({ stateInfo, stateRole }) => {
    const rows = [
        { title: 'Role', value: stateRole },
        { title: 'Full name', value: stateInfo.fullName },
        { title: 'Birthday', value: stateInfo.birthDate },
        { title: 'Gender', value: stateInfo.gender },
        { title: 'Address', value: stateInfo.address },
        { title: 'Phone number', value: stateInfo.phoneNo },
        { title: 'Citizen ID number', value: stateInfo.cardNumber },
    ]
    const imgCardPre = stateInfo.imgCard?.get(0)
    const imgCardPos = stateInfo.imgCard?.get(1)
    const [previewPre, setPreviewPre] = useState<string>()
    const [previewPos, setPreviewPos] = useState<string>()
    const preview = [previewPre, previewPos]
    const theme = useTheme()
    const [activeStep, setActiveStep] = React.useState(0)
    const maxSteps = 2

    useEffect(() => {
        if (imgCardPre) {
            const reader = new FileReader()
            reader.onload = () => {
                setPreviewPre(reader.result as string)
            }
            reader.readAsDataURL(imgCardPre)
        } else {
            setPreviewPre(undefined)
        }
    }, [imgCardPre])

    useEffect(() => {
        if (imgCardPos) {
            const reader = new FileReader()
            reader.onload = () => {
                setPreviewPos(reader.result as string)
            }
            reader.readAsDataURL(imgCardPos)
        } else {
            setPreviewPos(undefined)
        }
    }, [imgCardPos])

    const handleNext = () => {
        setActiveStep((prevActiveStep) => prevActiveStep + 1)
    }

    const handleBack = () => {
        setActiveStep((prevActiveStep) => prevActiveStep - 1)
    }
    return (
        <Styled.Step>
            <Box>
                <Grid container spacing={4}>
                    <Grid item xs={12} md={6}>
                        <TableContainer>
                            <Table
                                sx={{ maxWidth: 650 }}
                                aria-label="simple table"
                            >
                                <TableBody>
                                    {rows.map((row) => (
                                        <TableRow
                                            key={row.title}
                                            sx={{
                                                '&:last-child td, &:last-child th':
                                                    {
                                                        border: 0,
                                                    },
                                            }}
                                        >
                                            <TableCell
                                                component="th"
                                                scope="row"
                                            >
                                                {row.title}:
                                            </TableCell>
                                            <TableCell align="right">
                                                {row.value}
                                            </TableCell>
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <Box
                            sx={{
                                maxWidth: 400,
                                flexGrow: 1,
                                border: '1px solid #dadada',
                            }}
                        >
                            <Paper
                                square
                                elevation={0}
                                sx={{
                                    display: 'flex',
                                    alignItems: 'center',
                                    height: 50,
                                    pl: 2,
                                    bgcolor: 'background.default',
                                }}
                            >
                                <Typography>Citizen ID photo</Typography>
                            </Paper>
                            <CardMedia
                                component="img"
                                image={preview[activeStep]}
                                sx={{
                                    height: 255,
                                    maxWidth: 400,
                                    width: '100%',
                                    p: 2,
                                }}
                            />
                            <MobileStepper
                                variant="text"
                                steps={maxSteps}
                                position="static"
                                activeStep={activeStep}
                                nextButton={
                                    <Button
                                        size="small"
                                        onClick={handleNext}
                                        disabled={activeStep === maxSteps - 1}
                                    >
                                        Next
                                        {theme.direction === 'rtl' ? (
                                            <KeyboardArrowLeft />
                                        ) : (
                                            <KeyboardArrowRight />
                                        )}
                                    </Button>
                                }
                                backButton={
                                    <Button
                                        size="small"
                                        onClick={handleBack}
                                        disabled={activeStep === 0}
                                    >
                                        {theme.direction === 'rtl' ? (
                                            <KeyboardArrowRight />
                                        ) : (
                                            <KeyboardArrowLeft />
                                        )}
                                        Back
                                    </Button>
                                }
                            />
                        </Box>
                    </Grid>
                </Grid>
            </Box>
        </Styled.Step>
    )
}

const FillInformation: React.FunctionComponent<IFillInformationProps> = () => {
    const [information, setInformation] = useState<IInformation>({
        fullName: '',
        address: '',
        birthDate: '',
        cardNumber: '',
        gender: '',
        phoneNo: '',
        imgCard: new Map<number, File>(),
    })
    const [role, setRole] = useState<string>('Tenant')

    const [activeStep, setActiveStep] = React.useState(0)
    const [skipped, setSkipped] = React.useState(new Set<number>())

    const dispatch = useDispatch()
    const navigate = useNavigate()

    const isStepSkipped = (step: number) => {
        return skipped.has(step)
    }

    const callApi = async () => {
        const firebaseToken =
            await FirebaseService.getInstance().getFirebaseToken()
        const body: IFirstTimeBody = {
            firebaseToken,
            role: ROLES.findIndex((r) => r.name === role),
            name: information.fullName,
            address: information.address,
            dateOfBirth: new Date(information.birthDate),
            gender: GENDERS.findIndex(
                (gender) => information.gender === gender
            ),
            phone: information.phoneNo,
        }
        const firstTimeRes = await RestCaller.post(
            'Authentication/first-time-login',
            body
        )

        if (firstTimeRes.isError) return

        const firstTimeResult: IFirstTimeResponse = firstTimeRes.result
        const { token } = firstTimeResult

        console.log(token)

        dispatch(setToken(token))

        const uploadRes = await RestCaller.upload(
            'Users/upload-identification-card',
            (() => {
                const formData = new FormData()
                formData.append(
                    'FrontIdentification',
                    information.imgCard.get(0) as File
                )
                formData.append(
                    'BackIdentification',
                    information.imgCard.get(1) as File
                )
                return formData
            })()
        )

        if (uploadRes.isError) return
        navigate('/home')
    }

    const handleNext = () => {
        if (activeStep === STEPS.length - 1) {
            ;(async () => {
                await callApi()
            })()
            return
        }

        let newSkipped = skipped
        if (isStepSkipped(activeStep)) {
            newSkipped = new Set(newSkipped.values())
            newSkipped.delete(activeStep)
        }

        setActiveStep((prevActiveStep) => prevActiveStep + 1)
        setSkipped(newSkipped)
    }

    const handleBack = () => {
        setActiveStep((prevActiveStep) => prevActiveStep - 1)
    }

    const handleReset = () => {
        setActiveStep(0)
    }

    return (
        <Styled.Container>
            <Styled.MyPaper>
                <Box sx={{ width: '100%' }}>
                    <Stepper activeStep={activeStep} alternativeLabel>
                        {STEPS.map((label, index) => {
                            const stepProps: { completed?: boolean } = {}
                            const labelProps: {
                                optional?: React.ReactNode
                            } = {}
                            if (isStepSkipped(index)) {
                                stepProps.completed = false
                            }
                            return (
                                <Step key={label} {...stepProps}>
                                    <StepLabel {...labelProps}>
                                        {label}
                                    </StepLabel>
                                </Step>
                            )
                        })}
                    </Stepper>
                    <Styled.MainStep>
                        {(() => {
                            switch (activeStep) {
                                case STEPS.length:
                                    return (
                                        <React.Fragment>
                                            <Typography sx={{ mt: 2, mb: 1 }}>
                                                All steps completed -
                                                you&apos;re finished
                                            </Typography>
                                        </React.Fragment>
                                    )

                                case 0:
                                    return <SetRole onChangeState={setRole} />

                                case 1:
                                    return (
                                        <PersonalInformation
                                            state={information}
                                            onChangeState={setInformation}
                                        />
                                    )
                                case 2:
                                    return (
                                        <ConfirmInfo
                                            stateRole={role}
                                            stateInfo={information}
                                        />
                                    )
                                default:
                                    return <div>You are a User ({role}).</div>
                            }
                        })()}
                    </Styled.MainStep>

                    {activeStep === STEPS.length ? (
                        <React.Fragment>
                            <Box
                                sx={{
                                    display: 'flex',
                                    flexDirection: 'row',
                                    pt: 2,
                                }}
                            >
                                <Box sx={{ flex: '1 1 auto' }} />
                                <Button onClick={handleReset}>Reset</Button>
                            </Box>
                        </React.Fragment>
                    ) : (
                        <React.Fragment>
                            <Styled.ButtonBox
                                sx={{
                                    display: 'flex',
                                    flexDirection: 'row',
                                    pt: 2,
                                }}
                            >
                                <Button
                                    color="inherit"
                                    disabled={activeStep === 0}
                                    onClick={handleBack}
                                    sx={{ mr: 1 }}
                                >
                                    Back
                                </Button>
                                <Box sx={{ flex: '1 1 auto' }} />
                                <Button onClick={handleNext}>
                                    {activeStep === STEPS.length - 1
                                        ? 'Finish'
                                        : 'Next'}
                                </Button>
                            </Styled.ButtonBox>
                        </React.Fragment>
                    )}
                </Box>
            </Styled.MyPaper>
        </Styled.Container>
    )
}

export default FillInformation