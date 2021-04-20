<template>
  <q-page padding>
    <h5 class="q-ma-none q-mb-md">Мастер создания сотрудника.</h5>
    <q-form @submit="onSubmit" @reset="onReset">
      <q-card style="width: 750px" class="q-pa-md">
        <q-card-section class="row items-center justify-between q-pa-none no-wrap">
          <h6 class="text-primary text-weight-bold q-ma-none">Основная информация.</h6>
        </q-card-section>

        <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
          <span class="q-mr-lg" style="flex-shrink: 0">Полное имя</span>
          <q-input :disable="loading" style="width: 400px" dense filled v-model="form.fullName" label="Полное имя" />
        </q-card-section>

        <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
          <span class="q-mr-lg" style="flex-shrink: 0">Email</span>
          <q-input :disable="loading" style="width: 400px" dense filled v-model="form.email" label="Email" />
        </q-card-section>

        <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
          <span class="q-mr-lg" style="flex-shrink: 0">Номер телефона</span>
          <q-input :disable="loading" style="width: 400px" dense filled v-model="form.phone" label="Номер телефона" />
        </q-card-section>

        <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
          <span class="q-mr-lg" style="flex-shrink: 0">ИНН</span>
          <q-input :disable="loading" style="width: 400px" dense filled v-model="form.tin" label="ИНН" />
        </q-card-section>

        <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
          <span class="q-mr-lg" style="flex-shrink: 0">Дата рождения</span>
          <q-input :disable="loading" type="date" style="width: 400px" dense filled v-model="form.dateOfBirth" label="" />
        </q-card-section>

        <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
          <span class="q-mr-lg" style="flex-shrink: 0">Пол</span>
          <q-select option-label="label" option-value="value" :disable="loading" options-selected-class="text-deep-orange" style="width: 400px" dense filled v-model="form.gender" :options="genders" label="Пол" />
        </q-card-section>

        <q-card-actions class="flex justify-end">
          <q-btn :disable="loading" :loading="loading" type="submit" color="primary" glossy label="Сохранить" />
          <q-btn :disable="loading" :loading="loading" type="reset" color="deep-orange" flat label="Сбросить" />
          <q-btn @click="workInfoPopup = true" :disable="!isSuccessCreated" :loading="loading" color="purple" title="Указать информацию о компании и занимаемой должности (только после указания и сохранения основной информации)" glossy label="Заполнить рабочую информацию" />
        </q-card-actions>

      </q-card>
    </q-form>

    <q-dialog v-model="workInfoPopup" v-if="isSuccessCreated" persistent>
      <q-card style="width: 700px;">
        <q-card-section class="row items-center justify-between">
          <span class="q-ma-none text-h6 text-primary text-bold">Информация о рабочем месте сотрудника.</span>
        </q-card-section>

        <select-company-for-employee />

        <q-card-actions align="right">
          <q-btn flat label="Закрыть" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>

  </q-page>
</template>

<script>
import SelectCompanyForEmployee from 'components/selectElements/SelectCompanyForEmployee'
export default {
  name: 'CreateEmployeePage',
  components: { SelectCompanyForEmployee },
  data: () => {
    return {
      form: {
        gender: null,
        fullName: null,
        email: null,
        phone: null,
        tin: null,
        dateOfBirth: null,
        companyId: null,
        salary: null,
        positionId: null
      },
      workInfoPopup: false,
      isSuccessCreated: false,
      genders: [{ value: 'F', label: 'Женский' }, { value: 'M', label: 'Мужской' }],
      loading: false
    }
  },
  methods: {
    onSubmit () {
      this.loading = true
    },
    onReset () {
      this.form.gender = null
      this.form.fullName = null
      this.form.email = null
      this.form.phone = null
      this.form.tin = null
      this.form.dateOfBirth = null
    }
  }
}
</script>
