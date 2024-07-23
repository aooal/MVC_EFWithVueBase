<template>
    <div>
        <h1>This is .Net8 Mvc with EF CodeFirst and Vue Base Demo .</h1>
        <div class="card flex justify-center">
            <Button label="Check" icon="pi pi-check" @click="toggleDialog" />
            <Dialog v-model:visible="visible" modal :style="{ width: '25rem' }">
               <p>PrimVue Dialog</p>
            </Dialog>
        </div>
    </div>
</template>

<script>
    import { onMounted, ref } from 'vue';
    export default {
        name: 'Home',
        setup() {
            const visible = ref(false);
            const toggleDialog = () => {
                visible.value = !visible.value;
            }
            
            
            onMounted(() => {
                console.log('Home.vue component mounted');
            });

            
            return {
                toggleDialog,
                visible
            };
        }
    };
</script>