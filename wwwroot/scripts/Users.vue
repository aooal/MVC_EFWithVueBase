<template>
    <div>
        <div class="card flex justify-center">
            <Button label="Add" icon="pi pi-user-plus" @click="toggleDialog" raised />
            <Dialog v-model:visible="visible" modal :style="{ width: '25rem' }">
                <form @submit.prevent="onSubmit" class="form-group">
                    <div class="flex flex-column gap-2" style="margin-bottom: 10px">
                        <label for="name" class="m-4">Name</label>
                        <InputText id="name"
                                   v-model="name"
                                   type="text" />
                    </div>
                    <div class="flex justify-content-end mt-6">
                        <Button type="button"
                                label="清除"
                                @click="reset"
                                severity="secondary"
                                class="m-8"></Button>
                        <Button type="submit" label="確認"></Button>
                    </div>
                </form>
            </Dialog>
        </div>
        <Toast />
    </div>
</template>

<script>
    import { onMounted, ref, inject } from 'vue';
    import { useToast } from "primevue/usetoast";
    import axios from "axios";
    import Toast from "primevue/toast";

    export default {
        components: { Toast },
        name: 'Users',
        setup() {
            const hostname = inject("hostname");
            const toast = useToast();

            const visible = ref(false);
            const name = ref("");
            const email = ref("");
            const password = ref("");

            const toggleDialog = () => {
                visible.value = !visible.value;
            };

            const reset = () => {
                name.value = "";
                email.value = "";
                password.value = "";
                console.log('Resetting form...');
            };

            const onSubmit = () => {
                alert(`Name: ${name.value}, Email: ${email.value}, Password: ${password.value}`);
            };

            onMounted(() => {
                console.log('Users.vue component mounted');
            });

            return {
                toggleDialog,
                visible,
                onSubmit,
                name,
                email,
                password,
                reset
            };
        }
    };
</script>
