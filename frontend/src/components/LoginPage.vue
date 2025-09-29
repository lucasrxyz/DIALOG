<template>
    <v-container class="fill-height" fluid>
        <v-row align="center" justify="center">
            <v-col cols="12" sm="8" md="4">
                <v-card class="rounded-xl">
                    <v-card-title class="ma-5 text-h4 text-center"><b>Create an account</b></v-card-title>
                    <v-card-text>
                        <v-form ref="form" v-model="valid" lazy-validation>

                            <v-text-field v-model="email"
                                          :rules="[rules.required, rules.email]"
                                          label="Email"
                                          outlined
                                          dense />

                            <v-text-field v-model="displayName"
                                          label="Display Name"
                                          outlined
                                          dense />

                            <v-text-field v-model="username"
                                          :rules="[rules.required]"
                                          label="Username"
                                          outlined
                                          dense />

                            <v-text-field v-model="password"
                                          :rules="[rules.required, rules.min(6)]"
                                          label="Password"
                                          type="password"
                                          outlined
                                          dense />

                            <v-row>
                                <v-col cols="4">
                                    <v-select v-model="birthMonth"
                                              :items="months"
                                              label="Month"
                                              outlined
                                              dense />
                                </v-col>
                                <v-col cols="4">
                                    <v-select v-model="birthDay"
                                              :items="days"
                                              label="Day"
                                              outlined
                                              dense />
                                </v-col>
                                <v-col cols="4">
                                    <v-select v-model="birthYear"
                                              :items="years"
                                              label="Year"
                                              outlined
                                              dense />
                                </v-col>
                            </v-row>
                        </v-form>
                        <v-divider></v-divider>
                    </v-card-text>
                    <v-card-actions>
                        <v-btn color="#7f7dff"
                               class="mb-2 rounded-xl"
                               block
                               variant="outlined"
                               @click="register"
                               :disabled="!valid">
                            Continue
                        </v-btn>
                    </v-card-actions>
                </v-card>
            </v-col>
        </v-row>
    </v-container>
</template>

<script>
    import { useLoadingDialog } from "../utils/loadingDialog";

    export default {
        name: "RegisterPage",
        data() {
            return {
                email: "",
                displayName: "",
                username: "",
                password: "",
                birthMonth: null,
                birthDay: null,
                birthYear: null,
                acceptEmails: false,
                valid: false,
                months: [
                    "January", "February", "March", "April", "May", "June",
                    "July", "August", "September", "October", "November", "December"
                ],
                days: Array.from({ length: 31 }, (_, i) => i + 1),
                years: Array.from({ length: 100 }, (_, i) => new Date().getFullYear() - i),
                rules: {
                    required: (v) => !!v || "Required.",
                    email: (v) => /.+@.+\..+/.test(v) || "E-mail must be valid.",
                    min: (length) => (v) => (v && v.length >= length) || `Min ${length} characters.`
                },
            };
        },
        methods: {
            register() {
                if (this.$refs.form.validate()) {
                    const formData = {
                        email: this.email,
                        displayName: this.displayName,
                        username: this.username,
                        password: this.password,
                        birthDate: `${this.birthYear}-${this.birthMonth}-${this.birthDay}`,
                        acceptEmails: this.acceptEmails
                    };

                    // Sauvegarde dans localStorage
                    localStorage.setItem("registerData", JSON.stringify(formData));

                    console.log("Register data saved in localStorage:", formData);

                    const { dialoading } = useLoadingDialog();
                    dialoading(300);

                    // Redirection (Vue Router)
                    setTimeout(() => {
                        this.$router.push("/home");
                    }, 600);
                }
            } 
        },
    };
</script>
