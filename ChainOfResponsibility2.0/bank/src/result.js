import { Grid, Card, CardActionArea, CardMedia, CardContent, Typography, Container, Button } from "@mui/material";
import { useContext } from "react";
import { UserContext } from "./UserDataContext";
import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import { useNavigate } from "react-router-dom";

const images = {
    "5000" : "https://rossaprimavera.ru/static/files/e1b7973deeae.jpg",
    "1000" : "https://kollekcioner24.ru/image/catalog/20200426_114356.jpg",
    "500" : "https://coinsmoscow.ru/published/publicdata/COINSSR2WEBASYSTT/attachments/SC/products_pictures/23063-500r_2_enl.jpg",
    "100" : "https://cdn.tvspb.ru/storage/wp-content/uploads/2022/09/100d3bhsz5mdthumbnail_DRitpJi.webp__0_0x0.jpg",
    "50" : "https://static.auction.ru/offer_images/cmn8/2018/09/29/06/big/V/VPjQneGjtWV/50_rublej_1997_god_mod_2004_god_serija_chs_0405002_unc_3490.jpg",
    "10" : "https://avatars.mds.yandex.net/get-mpic/5235688/img_id4884758181562116444.jpeg/orig",
    "remains" : ""
}

function Result () {
    const { allBank } = useContext(UserContext)
    const navigate = useNavigate();
    return (
        <Container sx={{marginTop: 5, marginBottom: 5, display: 'flex', justifyContent: 'center', alignItems: 'center'}}>
            <Grid spacing={3} container >
                {allBank.map(element => (
                    <Grid key={element.value} item xs={5} sm={5} md={5} sx={{margin: '0 auto'}}>
                        <Card>
                        { (element.value !== 'remains') ? (
                            <CardActionArea>
                                <CardMedia
                                    component='img'
                                    height="140"
                                    image={images[element.value]}
                                    alt={element.value}
                                />
                                <CardContent>   
                                    <Typography gutterBottom variant="h5" component="div">
                                        Выдана банкнота номиналом {element.value} в количестве {element.count} на сумму {element.value * element.count} руб.
                                    </Typography>
                                </CardContent>
                            </CardActionArea>
                        ) : (
                            <CardActionArea>
                                <CardContent>
                                    <Typography gutterBottom variant="h5" component="div">
                                        Остаток от введенной суммы, который не может быть выдан: {element.count} руб.
                                    </Typography> 
                                </CardContent>
                            </CardActionArea>
                        )}
                        </Card>  
                    </Grid>
                ))}
                <Grid item xs={12} sm={12} md={12} sx={{display: 'flex', justifyContent: 'center', alignContent: 'center'}}>
                    <Button variant="contained" sx={{width: 40+'%', height: 5+'rem'}} startIcon={<ArrowBackIcon/>}
                        onClick={() => navigate('/input')}
                    />
                </Grid>
            </Grid>
        </Container>
    )
}

export default Result;
