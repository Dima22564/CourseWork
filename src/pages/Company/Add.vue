<template>
  <div class="q-pa-md">
    <q-stepper
      v-model="step"
      vertical
      color="primary"
      animated
    >
      <q-step
        :name="1"
        title="Заполните данные о компании"
        icon="settings"
        caption="обязательно для заполнения"
        :done="step > 1"
      >
        <q-form
          class="q-gutter-md"
          @submit.prevent=""
          ref="companyData"
        >
          <q-input
            filled
            v-model="tin"
            label="Введите Инн"
            hint="Tin"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />

          <q-input
            filled
            v-model="crtr"
            label="Введите Crtr"
            hint="Crtr"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />

          <q-input
            filled
            v-model="registrationNumber"
            label="Введите регистрационный номер"
            hint="Введите регистрационный номер"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />

          <q-input
            filled
            v-model="registrationDate"
            label=""
            hint="Введите дату регистрации"
            type="date"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />
        </q-form>

        <q-stepper-navigation>
          <q-btn @click="nextStep($refs.companyData, 2)" color="primary" label="Далее" />
        </q-stepper-navigation>
      </q-step>

      <q-step
        :name="2"
        title="Заполните адресс компании"
        caption="обязательно для заполнения"
        icon="create_new_folder"
        :done="step > 2"
      >
        <q-form
          class="q-gutter-md"
          @submit.prevent=""
          ref="companyAddress"
        >
          <q-input
            filled
            v-model="legalAddress"
            label="Введите юридический адрес компании"
            hint="Введите юридический адрес компании"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />

          <q-input
            filled
            v-model="physicalAddress"
            label="Введите физический адрес компании"
            hint="Введите физический адрес компании"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />
        </q-form>

        <q-stepper-navigation>
          <q-btn @click="nextStep($refs.companyAddress, 3)" color="primary" label="Далее" />
          <q-btn flat @click="step = 1" color="primary" label="Назад" class="q-ml-sm" />
        </q-stepper-navigation>
      </q-step>

      <q-step
        :name="3"
        title="Заполните контактные данные"
        caption="обязательно для заполнения"
        icon="create_new_folder"
        :done="step > 3"
      >
        <q-form
          class="q-gutter-md"
          @submit.prevent=""
          ref="companyContacts"
        >
          <q-input
            filled
            v-model="email"
            label="Введите контактный email"
            hint="Введите контактный email"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />

          <q-input
            filled
            v-model="phone"
            label="Введите контактный телефон"
            hint="Введите контактный телефон"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />

        </q-form>

        <q-stepper-navigation>
          <q-btn @click="onSubmit" color="primary" label="Создать" :loading="loading" />
          <q-btn flat @click="step = 2" color="primary" label="Назад" class="q-ml-sm" :loading="loading" />
        </q-stepper-navigation>
      </q-step>

    </q-stepper>
  </div>
</template>

<script>
export default {
  data () {
    return {
      step: 1,
      loading: false,
      abbreviation: '',
      internationalName: '',
      tin: '',
      crtr: '',
      registrationNumber: '',
      registrationDate: '',
      legalAddress: '',
      physicalAddress: '',
      phone: '',
      email: ''
    }
  },
  methods: {
    async onSubmit () {
      this.loading = true
      const success = await this.$refs.companyContacts.validate()
      if (success) {

      }
    },
    nextStep (form, step) {
      form.validate().then(success => {
        if (success) {
          this.step = step
        }
      })
    }
  }
}
</script>
