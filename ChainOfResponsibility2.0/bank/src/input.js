import { Button, Container, TextField, Grid, Snackbar, Alert } from '@mui/material';
import {useContext, useEffect, useState} from 'react';
import { useNavigate } from 'react-router-dom';
import { UserContext } from './UserDataContext';

const keys = [
    { text: '7', value: 7 },
    { text: '8', value: 8 },
    { text: '9', value: 9 },
    { text: '4', value: 4 },
    { text: '5', value: 5 },
    { text: '6', value: 6 },
    { text: '1', value: 1 },
    { text: '2', value: 2 },
    { text: '3', value: 3 },
    { text: 'DEL', value: 'del' },
    { text: '0', value: 0 },
    { text: 'Отправить', value: 'send' },
];



function Input() { 
  const {handleRequest, resultValue, setResultValue} = useContext(UserContext)
  const [value, setValue] = useState('');
  const [snackbarOpen, setSnackbarOpen] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    setValue(resultValue);
  }, [resultValue, setValue])

  function handleSend(){
    handleRequest({value, navigate, handleClick})
  }

  const handleClick = (message) => {
    setSnackbarOpen(message);
  };

  const handleClose = (event, reason) => {
    if (reason === 'clickaway') {
      return;
    }

    setSnackbarOpen(false);
  };

  return (
    <>
    <Snackbar 
        severity="error"
        open={snackbarOpen}
        autoHideDuration={3000}
        onClose={handleClose}
        message="Note archived"
        action={handleClick}
    >
        <Alert
          onClose={handleClose}
          severity="error"
          variant="filled"
          sx={{ width: '100%' }}
        >
          {snackbarOpen}
        </Alert>
    </Snackbar>
    <Container sx={{display: 'flex', height: 100+'vh', justifyContent: 'center', alignItems: 'center'}}>
        <Grid spacing={2} container sx={{ maxWidth: 500}}>
            <Grid item xs={12} sm={12} md={12}>
                <TextField inputRef={input => input && input.focus()} sx={{height: '100%', width: '100%'}} id="summ" label="Сумма к снятию" placeholder='0' variant="filled" value={value} onChange={(e) => {
                    if (Number.isInteger(+e.target.value)) {
                        if (e.target.value > 500000) return handleClick('Предельно допустимая сумма 500 000 руб.')
                        setResultValue(e.target.value)
                    } else handleClick('Допускается ввод только натуральных чисел');
                }} />
            </Grid>
            {keys.map(item => (
                <Grid  key={item.value} item xs={4} sm={4} md={4}>
                    {(item.value !== 'send' && item.value !== 'del') ? (
                        <Button sx={{height: '100%', width: '100%'}} variant="outlined" key={item.value} onClick={() => {
                            if (value * 10 + item.value > 500000) return handleClick('Предельно допустимая сумма 500 000 руб.')
                            return setResultValue((value) ? value * 10 + item.value : item.value)}
                        }>{item.value}</Button>
                    ) : (item.value !== 'del') ? (
                        <Button sx={{height: '100%', width: '100%'}} variant="contained" key={item.value} onClick={() => handleSend()}>{item.value}</Button>
                    ) : (
                        <Button sx={{height: '100%', width: '100%'}} color="error" variant="contained" key={item.value} onClick={() => setResultValue('')}>{item.value}</Button>
                    )}
                </Grid>
                )
            )}
        </Grid>
    </Container>
    </>
  );
}

export default Input;
